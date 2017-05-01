using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveSimple : MonoBehaviour {
    //Public Variables
    public float fl_movespeed;
    public float fl_turnSpeed;
    //privat Variables
    private Rigidbody rb_player;

    //Debug
    public float mousePosX;
    public float mouseposY;
	// Use this for initialization
	void Start () {
        rb_player = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        mousePosX = Input.mousePosition.x - (Screen.width/2);
        mouseposY = Input.mousePosition.y - (Screen.height/2);
        Move();
        Turn();
	}
    void Move()
    {
        rb_player.AddRelativeForce(Vector3.forward * fl_movespeed * Input.GetAxis("Vertical"));
    }
    void Turn()
    {
        //Script to point the ship in the direction of the mouse cursor.

    }
}
