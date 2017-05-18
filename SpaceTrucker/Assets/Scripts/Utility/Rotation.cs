using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
    //Simple script to import rotation on the station.
    public float RotationSpeed;
    public Vector3 RotationDirection;
	// Use this for initialization
	void Update () {
        transform.Rotate(RotationDirection, RotationSpeed * Time.deltaTime);
	}
}
