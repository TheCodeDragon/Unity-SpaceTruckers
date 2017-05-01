using UnityEngine;
using System.Collections;

//The "Bug" was calling my Method RayCastHit, turns out unity has one of those but rather than a useful error message
//it comes up with some rubbish, fixed it by simply renaming methond

public class RaycastTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckClicked ();
	}
	void CheckClicked() {       //Handle raycast, if we hit an cube start it tumbbling
		RaycastHit tHit;
		if (Input.GetMouseButtonDown (0)) {
			Ray	tRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (tRay, out tHit)) {
				Debug.DrawRay (tRay.origin, tHit.point-tRay.origin, Color.red,2f);      //Debug
				RotateCube tRC = tHit.collider.gameObject.GetComponent<RotateCube> ();
				if (tRC != null) {
					tHit.collider.gameObject.GetComponent<MeshRenderer> ().material.color = Random.ColorHSV ();
					tRC.Tumble = !tRC.Tumble;
				}
			}
		}
	}
}