using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookAt : MonoBehaviour {

	public	Transform	Target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Target != null) {
			transform.LookAt (Target);
		}
	}
}
