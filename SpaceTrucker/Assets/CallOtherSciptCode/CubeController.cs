using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	public	CubeRotator	mCR;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mCR.RotateMe (Time.deltaTime);
	}
}
