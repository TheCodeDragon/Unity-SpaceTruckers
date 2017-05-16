using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {
    //Weapon Script. this is the core script for every weapon the player uses. Mining laser and phaser. This will of course be
    //Used as the base for other weapon types, such as torpedo.

    public string st_DamageType;
    public float fl_Damage;
    public float fl_Range;
    private LineRenderer Laser;
    //Cooldown for laser
    public float fl_Overheat; //The time it takes for the laser to overheat
    public float fl_CoolDown; //The cooldown
    //Sound Effects
    private AudioSource AU_Source;

    // Use this for initialization
    void Start () {
        AU_Source = GetComponent<AudioSource>();//Gets the audio source
        AU_Source.Stop();
        Laser = GetComponent<LineRenderer>();//Sets the line renderer
        Laser.SetPosition(1, Vector3.zero);//Resets the laser.
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward);
        if (Input.GetButton("Fire1"))
        {
            Fire(true);
        }
        else
        {
            Fire(false);
        }
	}
    void Fire(bool isFiring)
    {
        //Setup for raycast
        RaycastHit mHit;
        //The laser can only fire if the cooldown is less than the overheat, a safety measure to prevent it exploding or
        //Melting. Future advancements could have it so that when there's an overheat, it forces the weapon
        //offline.
        //If true, fire laser
        if (isFiring)
        {
            if (fl_CoolDown < fl_Overheat)
            {
                //Fire Laser
                Physics.Raycast(transform.position, transform.forward, out mHit);//Raycasts forward.
                AU_Source.Play();//Play the laser effect
                Laser.SetPosition(1, Vector3.forward * fl_Range);//Shoot laser effect
                //Do check for distance - if within range, do damage.
                if(mHit.collider != null)
                {
                    if(mHit.distance <= fl_Range)
                    {
                        mHit.collider.gameObject.SendMessage("OnDamage", fl_Damage, SendMessageOptions.DontRequireReceiver);
                        Debug.Log(mHit.collider.gameObject.name + " Has been hit.");
                        Debug.Log(mHit.point + " " + mHit.distance);
                    }
                }
                fl_CoolDown += Time.deltaTime;//Increase cooldown towards overheat
            }
            else
            {
                Laser.SetPosition(1, Vector3.zero);//cancel laser effect
                AU_Source.Stop();//Cancel Laser Sound effect
            }
        }
        //If false, reset laser.
        else
        {
            if (fl_CoolDown > 0)
            {
                Laser.SetPosition(1, Vector3.zero);//cancel laser effect
                AU_Source.Stop();//Cancel Laser Sound effect
                fl_CoolDown -= Time.deltaTime;//Decrease from cooldown
            }
            else
            {
                fl_CoolDown = 0;//Sets cooldown to zero for sanity
            }
        }
    }
}
