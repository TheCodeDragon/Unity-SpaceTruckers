using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {


	Text	mCountDownText;

	float	mTimer;

	void	Start() {
		mCountDownText = GetComponent<Text> ();
		ResetTimer (5f);
	}

	public	void	ResetTimer(float vTime) {
		mTimer = vTime;
		mCountDownText.color = Color.white;
	}

	// Update is called once per frame
	void Update () {
		if (mTimer > 0f) {
			mTimer -= Time.deltaTime;
			mCountDownText.text = string.Format ("{0:f2}", mTimer);
		} else {
			mTimer = 0f;
			mCountDownText.text = string.Format ("{0:f2}", mTimer);
			mCountDownText.color = Color.red;
		}
	}
}
