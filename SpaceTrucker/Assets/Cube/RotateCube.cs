using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {

	[Range(180f,360*10)]
	public	float Speed=100f;

	Vector3	mStartPosition;
	Quaternion mStartRotation;

	bool	mTumble=false;

	public	bool	Tumble {		//Setter and getter for tumble flag
		set {
			mTumble = value;
		}
		get {
			return	mTumble;
		}
	}

	// Use this for initialization
	void Start () {
		mStartPosition = transform.position;		//Remember start position
		mStartRotation = transform.rotation;
		Tumble = true;
	}

	public	void	Reset () {
		transform.position=mStartPosition;
		transform.rotation=mStartRotation;
	}

	// Update is called once per frame
	void Update () {
		if (mTumble) {
			transform.Rotate (-Speed * Time.deltaTime, 0, 0);
			float	tEdge = Mathf.Sqrt (2f);
			float	tHeight = Mathf.Abs (Mathf.Sin (transform.rotation.eulerAngles.x * Mathf.Deg2Rad * 2f));
			float	tDisp = tEdge;
			transform.position = new Vector3 (transform.position.x, 0.5f + (tEdge / 2.0f - 0.5f) * tHeight, transform.position.z - tDisp * Time.deltaTime);
		}
	}
}
