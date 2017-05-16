using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplane : MonoBehaviour {

    Vector2 mLastMouse = Vector2.zero;      //Used to work out mouse move delta's

    private float Pitch = 0f;       //Plane pitch, ie nose up/down
    private float Yaw = 0f;         //Plae Yaw, ie rudder
    public float Speed = 0f;       //Plane speed
    //Speed limiter
    public float SpeedMax = 30F;
    public float SpeedMin = -5F;
    //Roll, pitch, yaw variables.
	public	float Roll=0f;			//Roll Angle
    public float rcs = 10F; // Roll speed modifier
    public float pseudoMass = 5f;
    //Link to player Script
    public GameObject GO_Player;
    private PlayerScript sc_Player;
    //All important Boolean.
    private bool bl_CanMove = true;
	void	Start() {
        sc_Player = GO_Player.GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
        //Ship Movement
        if (bl_CanMove)
        {
            MoveShip();
        }
        //Speed limiter
        SpeedLimiter();
        //Fuel Consumptions
        ConsumeFuel();
    }
    void MoveShip()
    {
        Vector2 tCurrentMouse = Input.mousePosition;        //Work out relative mouse move since last frame
        //Work out the middle of the screen
        Vector2 tScreenMiddle = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 tDeltaMouse = tCurrentMouse - tScreenMiddle; //changed to calculate the difference between the mouse and the middle.

        //Roll controls - Export to input manager
        if (Input.GetButton("CCWRoll"))
        {
            Roll -= Time.deltaTime * rcs; //Removed link, since space ships should be able to roll without speed.
        }

        if (Input.GetButton("CWRoll"))
        {
            Roll += Time.deltaTime * rcs; //Removed link, since space ships should be able to roll without speed.
        }

        Pitch += tDeltaMouse.y / pseudoMass / 1; ///1 to invert controls         //Calculate Pitch and Yaw seperatly based on mouse delta
        Yaw += tDeltaMouse.x / pseudoMass / 1;           //Introduced the PseudoMass, which adds a lag to moving the camera so it feels like there's a bigger ship involved.

        Quaternion tRotation = Quaternion.Euler(Pitch, Yaw, Roll);      //Work out Angle from pitch & Yaw, Fix roll at 0

        transform.rotation *= tRotation;       //Apply To Plane, camera is parented so it will follow
        transform.position += transform.forward * Speed * Time.deltaTime;        //Work out new position having done rotation
        Speed += Input.GetAxis("Mouse ScrollWheel") * 10f;

        Pitch = Yaw = Roll = 0.0f;
    }
    void SpeedLimiter()
    {
        if (Speed > SpeedMax)
        {
            Speed = SpeedMax;
        }
        if (Speed < SpeedMin)
        {
            Speed = SpeedMin;
        }
    }
    void ConsumeFuel()
    {
        if(sc_Player.fl_FuelCurrent > 0)
        {
            sc_Player.fl_FuelCurrent -= sc_Player.fl_FuelConsumption * Speed;
        }
        else
        {
            bl_CanMove = false;
        }
    }
}
