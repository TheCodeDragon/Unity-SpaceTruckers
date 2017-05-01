using UnityEngine;
using System.Collections;

public class PlayerHit : MonoBehaviour {


	void	Start() {
	}

	float	mSpinTime=0f;
		
	void	Update() {
		if (mSpinTime > 0f) {
			transform.Rotate (Time.deltaTime*360f, 0, 0);
			mSpinTime -= Time.deltaTime;
		} else {
			mSpinTime = 0;
		}
	}

	void OnTriggerEnter(Collider vOther) {
		RotateCube	tCubeRotate = vOther.GetComponent<RotateCube> ();
		if (tCubeRotate != null) {
			mSpinTime = 1f;
			Debug.Log ("Cube Hit " + tCubeRotate.gameObject.name);		
		}
	}	
}
