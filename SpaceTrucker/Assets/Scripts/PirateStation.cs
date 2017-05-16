using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateStation : MonoBehaviour {
    //The script for managing the station.
    /*> Spawn drones when player is close
     */
    [Header("Drone Spawning")]
    public Transform spawnLocation; //Where to spawn them
    public GameObject drone;        //Drone
    public float spawnCooldown;     //How often they spawn
    public float timer;             //Spawn timer.
    public float ScanningRange;     //How close the player can be before they start spawning

    //Private variables
    //*Music*//
    private GameObject Player;
    private PlayerScript pcScript;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        pcScript = Player.GetComponent<PlayerScript>();

    }
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
        {
            SpawnDrone();
            timer = spawnCooldown;
        }
        timer -= Time.deltaTime;
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) <= ScanningRange)
        {
            playerBattleMusic(true);
        }
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > ScanningRange)
        {
            playerBattleMusic(false);
        }
    }
    void SpawnDrone()
    {
        //gameObject.transform.position - GameObject.Find("Player").transform.position 
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) <= ScanningRange)
        {
            GameObject tDrone = drone;
            Instantiate(tDrone, spawnLocation);
            tDrone.transform.SetParent(null);
        }
        else if(Vector3.Distance(gameObject.transform.position, Player.transform.position) > ScanningRange)
        {
            
            return;
        }
    }
    void playerBattleMusic(bool isBattle)
    {
        if(isBattle)
        {
            pcScript.inBattle = true;
        }
        else
        {
            pcScript.inBattle = false;
        }
    }
}
