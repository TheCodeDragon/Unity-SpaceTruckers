using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehaviourScript : MonoBehaviour {
    //Basic Drone behaviour Script.
    // Use this for initialization
    //This works by having two distances: Chase and Combat
    /*  Player Distance > Chase                         = Patrol Behaviour
     *  Chase           > Player Distance   > Combat    = Chase Behavior
     *  Combat          > Player Distance               = Combat Behaviour
     */
    //Public Variables
    [Header("Distance Config")]
    public float ChaseDistance;
    public float CombatDistance;
    public float HomeDistance;
    [Header("Movement Config")]
    public float MoveSpeed;
    public float TurnSpeed;
    public GameObject Home;
    [Header("Drone Combat Config")]
    public float Range;
    public float Damage;
    //Private variables
    //**Laser**//
    private LineRenderer LaserLine;
    private GameObject Player;
    private float playerDistance;
	void Start () {
        Player = GameObject.Find("Player");
        Home = GameObject.Find("Pirate_Station");
        LaserLine = GetComponent<LineRenderer>();
        LaserLine.SetPosition(1, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector3.Distance(transform.position, Player.transform.position);
        if(Home == null)
        {
            Destroy(gameObject);//Clean up any drones left over if the pirate base has been destroyed.
        }
        if(playerDistance > ChaseDistance)
        {
            LaserLine.SetPosition(1, Vector3.zero);
            Patrol();
        }
        else if(ChaseDistance > playerDistance && playerDistance > CombatDistance)
        {
            LaserLine.SetPosition(1, Vector3.zero);
            Chase();
        }
        else
        {
            Combat();
        }


    }
    void Patrol()
    {
        //No player found? Head to the base and rotate around it.  
        if(Vector3.Distance(Home.transform.position, gameObject.transform.position) >HomeDistance)
        {
            transform.LookAt(Home.transform.position);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else
        {
            transform.RotateAround(Home.transform.position, Vector3.up, TurnSpeed);
        }
    }
    void Chase()
    {
        //Step 1: Calculate the needed rotation
        Quaternion RotationNeeded = Quaternion.LookRotation(Player.transform.position, transform.position);
        //step 2: Slowly turn to follow this, using the turn speed.
        Quaternion.Slerp(transform.rotation, RotationNeeded, Time.deltaTime * TurnSpeed);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }
    void Combat()
    {
        transform.LookAt(Player.transform.position);
        Attack(Player);
    }
    void Attack(GameObject Target)
    {
        //Send damage message, fire lasers.
        RaycastHit mHit;
        Physics.Raycast(transform.position, transform.forward, out mHit);
        if (mHit.distance <= CombatDistance)
        {
            if (mHit.collider != null)
            {
                if (mHit.distance <= Range)
                {
                    LaserLine.SetPosition(1, Vector3.forward * Range);
                    mHit.collider.gameObject.SendMessage("OnDamage", Damage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        else
        {
            LaserLine.SetPosition(1, Vector3.zero);
        }
    }
}
