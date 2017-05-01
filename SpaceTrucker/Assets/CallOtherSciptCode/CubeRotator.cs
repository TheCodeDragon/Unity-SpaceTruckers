using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public	void	RotateMe(float vTime) {
		transform.Rotate (45f*vTime, 45f*vTime, 0);
	}
}
