using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedDisplay : MonoBehaviour {
    //Basic display setting script//
    public GameObject GO_player;
    public Text TX_displayScreen;
    //Extra display details
    public GameObject GO_SpeedBar;
    private RectTransform RTR_SpeedBar;
    public float fl_maxLength;
    private float fl_Length;

    //private variables
    private Moveplane sc_speedScript;
    private float fl_displaySpeed;
	// Use this for initialization
	void Start () {
        sc_speedScript = GO_player.GetComponent<Moveplane>();
        RTR_SpeedBar = GO_SpeedBar.GetComponent<RectTransform>();
        fl_maxLength = RTR_SpeedBar.rect.width;
	}
	
	// Update is called once per frame
	void Update () {
        fl_displaySpeed = Mathf.RoundToInt(sc_speedScript.Speed);
        TX_displayScreen.text = fl_displaySpeed + " M/S";
        fl_Length = fl_maxLength / sc_speedScript.SpeedMax * fl_displaySpeed;
        RTR_SpeedBar.sizeDelta = new Vector2(fl_Length,500);
	}
}
