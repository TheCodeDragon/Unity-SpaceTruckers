using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHealth : MonoBehaviour {
    //public Variables
    public float Shield;
    private float Maxshield;
    public bool CanRegen;
    public float Regen;
    public float Health;
    public float RUOnDeath;
    //Private Variables
    private GameObject GO_Player;
    private PlayerScript sc_Player;
    // Use this for initialization
    void Start () {
        //Start
        GO_Player = GameObject.Find("Player");
        sc_Player = GO_Player.GetComponent<PlayerScript>();
        Maxshield = Shield;
    }
	
	// Update is called once per frame
	void Update () {
        //Update
        ShieldRegen(CanRegen);
        if (Health <= 0)
        {
            Die();
        }
    }
    //Shield Regeneration
    public void ShieldRegen(bool isActive)
    {
        if(isActive)
        {
            if(Shield > Maxshield)
            {
                Shield += Regen * Time.deltaTime;
            }
        }
    }
    //Other
    public void OnDamage(float Damage)
    {
        if (Shield > 0)
        {
            Shield -= Damage;
        }
        else
        {
            Health -= Damage;
        }
    }
    void Die()
    {
        sc_Player.RUAdd(RUOnDeath);
        Destroy(gameObject);
    }


}
