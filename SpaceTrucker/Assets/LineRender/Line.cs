using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {

	MeshFilter		mMF;
	LineRenderer	mLR;
	Vector3[]	mVectors;
	int	tCount=100;

	float	tOffset=0f;

	// Use this for initialization
	void Start () {
		mMF = GetComponent<MeshFilter> ();
		mLR = GetComponent<LineRenderer> ();
		mVectors=new Vector3[tCount];
	}
	
	// Update is called once per frame
	void Update () {
		for (int tI = 0; tI < tCount; tI++) {
			float	tX=-Mathf.PI + ((2 * tI * Mathf.PI)/tCount);
			mVectors[tI]=new Vector3(tX,Mathf.Sin(tX+tOffset),Mathf.Cos(tX+tOffset));
		}
		mLR.SetVertexCount (mVectors.Length);
		mLR.SetPositions (mVectors);
		tOffset += Time.deltaTime;
	}
}
