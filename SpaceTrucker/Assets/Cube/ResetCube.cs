using UnityEngine;
using System.Collections;

public class ResetCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider vOther) {		//When we exit table we hit collider so reset
		RotateCube tCubeRotate=vOther.GetComponent<RotateCube>();		//Get Cube Script
		if (tCubeRotate != null) {		//Is it a Cube script
			tCubeRotate.Reset ();
		}
	}
}
