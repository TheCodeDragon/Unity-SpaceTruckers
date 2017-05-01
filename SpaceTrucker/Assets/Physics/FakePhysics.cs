using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePhysics : MonoBehaviour {

	public	Vector3		Velocity=Vector2.zero;
	public	Vector3 	Accelleration = Vector2.zero;
	public	Vector3		Force=Vector3.zero;
	public	float 		Mass;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Accelleration = Force / Mass;
		Velocity += Accelleration*Time.deltaTime;
		transform.position +=Velocity * Time.deltaTime;
		Wrap ();
	}

	void Wrap () {
		float	tHeight = Camera.main.orthographicSize;
		float	tWidth = tHeight * Camera.main.aspect;
		if (transform.position.x < -tWidth) {
			transform.position += 2*Vector3.right*tWidth;
		} else 	if (transform.position.x > tWidth) {
			transform.position += 2*Vector3.left*tWidth;
		}
		if (transform.position.y < -tHeight) {
			transform.position += 2*Vector3.up*tHeight;
		} else 	if (transform.position.y > tHeight) {
			transform.position += 2*Vector3.up*tHeight;
		}
	}
}

