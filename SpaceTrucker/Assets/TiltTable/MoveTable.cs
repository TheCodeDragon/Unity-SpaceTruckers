using UnityEngine;
using System.Collections;

public class MoveTable : MonoBehaviour {

	[Range(1f,100f)]
	public	float Speed=10f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		float	tX=transform.rotation.eulerAngles.x;
		float	tY=transform.rotation.eulerAngles.y;
		float	tZ=transform.rotation.eulerAngles.z;
		if (Input.GetKey (KeyCode.UpArrow)) {
			tX += Time.deltaTime*Speed;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			tX -= Time.deltaTime*Speed;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			tZ += Time.deltaTime*Speed;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			tZ -= Time.deltaTime*Speed;
		}
		transform.rotation = Quaternion.Euler(tX,tY,tZ);
	}
}
