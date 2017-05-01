using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]     //Runs this code in editor

public class AutoName : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GetComponentInChildren<TextMesh>().text=name;
	}
}
