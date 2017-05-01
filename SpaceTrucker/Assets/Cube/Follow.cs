using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public	Transform	Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once pe	r frame
	void Update () {
		Vector3	tPosition = new Vector3 (Target.position.x, transform.position.y, Target.position.z);
		transform.position = tPosition;
	}
}
