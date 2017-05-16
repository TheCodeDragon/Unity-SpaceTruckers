using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueDisplay : MonoBehaviour {
    //GUI Value Displayer
    /*This the 6 player stats, and then displays it.
     *
     */
     //Link to player Script
    public GameObject GO_Player;
    private PlayerScript sc_Script;
    //Link to Texts
    [Header("Text Links")]
    public Text tx_Health;
    public Text tx_Fuel;
    public Text tx_Shield;
    public Text tx_Cargo;
    public Text tx_Credits;
    [Header("Alarm Clips")]
    public AudioClip[] AlarmClips;

    // Use this for initialization
    void Start () {
        sc_Script = GO_Player.GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        //Health
        Stat(sc_Script.fl_HealthMax, sc_Script.fl_HealthCurrent, tx_Health, "");
        //Fuel
        Stat(sc_Script.fl_FuelMax, sc_Script.fl_FuelCurrent, tx_Fuel, "");
        //shield
        Stat(sc_Script.fl_ShieldMax, sc_Script.fl_ShieldCurrent, tx_Shield, "");
        //Cargo
        Stat(sc_Script.fl_CargoMax, sc_Script.fl_CargoCurrent, tx_Cargo, "");
        //Credis
        Credit(sc_Script.in_Credits, tx_Credits, "");

        //Alarm
        Alarm(sc_Script.fl_ShieldMax, sc_Script.fl_ShieldCurrent);
    }
    //Stat fields:
    /* Max - The maximum value
     * Current - Current value
     * field - Tex field to work
     * prefix - Symbol to use, for the field.
     */
    void Stat(float fl_MaxValue, float fl_CurrentValue, Text Field ,string st_Prefix)
    {
        Field.text = st_Prefix + Mathf.RoundToInt(fl_CurrentValue);//Sets the text. Rounded to a whole integer for clarity.
        GameObject GO_Panel = Field.transform.FindChild("Panel").gameObject;//Grabs the panel in the child.
        RectTransform panelRect = GO_Panel.GetComponentInChildren<RectTransform>();//Gets the Rect of the panel
        float fl_length = 100 / fl_MaxValue * fl_CurrentValue;//does the maths for the bar length
        panelRect.sizeDelta = new Vector2(100 / fl_MaxValue * fl_CurrentValue, 30);//Applies the new length
        //This should work to the formula (100/MaxValue)*CurrentValue.  
        //TODO: Add colour changing depending on the width.DONE:
        Image Panelimage = panelRect.GetComponent<Image>();
        Panelimage.color = colourChange(fl_MaxValue, fl_CurrentValue);
        
    }
    //Because credits aren't capped, they do need a seperate method of displaying.
    void Credit(int in_Value, Text Field, string st_Prefix)
    {
        Field.text = st_Prefix + in_Value;
    }
    //Added Frill to the stat bar
    Color colourChange(float fl_Max, float fl_cur)
    {
        Color red = new Color(1, 0, 0, 0.5F);
        Color yellow = new Color(1, 1, 0, 0.5F);
        Color green = new Color(0, 1, 0, 0.5F);
        if(fl_cur >= (fl_Max/4)*3)// 3/4 to max = Green
        {
            return green;
        }
        if(fl_cur <= fl_Max/4)// 1/4 to 0 = Red
        {
            return red;
        }
        else// Everything else, Yellow.
        {
            return yellow;
        }

    }
    //Alarms
    void Alarm(float MaxShield, float CurrentShield)
    {
        AudioSource alarm = GetComponent<AudioSource>();
        bool AlarmActive = false;
        if(CurrentShield <= (MaxShield/4)*3 && CurrentShield > MaxShield/2)
        {
            alarm.clip = AlarmClips[0];
            AlarmActive = true;
        }
        else if(CurrentShield <= MaxShield/2 && CurrentShield > MaxShield/4)
        {
            alarm.clip = AlarmClips[1];
            AlarmActive = true;
        }
        else if(CurrentShield <=MaxShield/4)
        {
            alarm.clip = AlarmClips[2];
            AlarmActive = true;
        }

        if(AlarmActive)
        {
            if(!alarm.isPlaying)
            {
                alarm.Play();
            }
        }
        else
        {
            alarm.Stop();
        }


    }

}
