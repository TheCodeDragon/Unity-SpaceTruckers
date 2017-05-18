using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    //Player Script
    //This is the base script for the player. Health and weapon selection. Also, holds the values for other scripts to use.
    [Header("Health and Shields")]
    public float fl_HealthMax;
    public float fl_HealthCurrent;
    public float fl_ShieldMax;
    public float fl_ShieldCurrent;
    public float fl_ShieldRegen;
    [Header("Fuel and Movement")]
    public float fl_FuelMax;
    public float fl_FuelCurrent;
    [Range(0.0001F, 0.001F)]
    public float fl_FuelConsumption;
    public float fl_CargoMax;
    public float fl_CargoCurrent;
    public int in_Credits;
    [Header("Music")]
    public AudioClip[] Music;
    public bool inBattle;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //Shield Regen
        ShieldRegen();
        //Health manager
        HealthManage();
        //Music
        MusicController(inBattle);
        if(fl_HealthCurrent < 0)
        {
            Destroy(gameObject);
        }

	}
    void ShieldRegen()
    {
        if (fl_ShieldCurrent < fl_ShieldMax)
        {
            fl_ShieldCurrent += fl_ShieldRegen * Time.deltaTime;
        }
    }
    void HealthManage()
    {
        if(fl_HealthCurrent > fl_HealthMax)
        {
            fl_HealthCurrent = fl_HealthMax;
        }
    }

    //interaction functions
    public void RUAdd(float RU)
    {
        //Step 1 - Check the cargo isn't full
        if(fl_CargoCurrent < fl_CargoMax)
        {
            //Step 2 - Check cargo + new RU won't overload it
            if(fl_CargoCurrent + RU >= fl_CargoMax)
            {
                //If so, just set it to Max
                fl_CargoCurrent = fl_CargoMax;
            }
            else
            {
                fl_CargoCurrent += RU;
            }
            
            
        }
        //log debug
        else
        {
            Debug.Log("Cargo full!");
        }
    }
    public void OnDamage(float DMG)
    {
        AudioSource AudSource = GetComponent<AudioSource>();
        
        if(fl_ShieldCurrent > 0)
        {
            fl_ShieldCurrent -= DMG * Time.deltaTime;
        }
        else
        {
            fl_HealthCurrent -= DMG * Time.deltaTime;
        }
    }

    //Repairs any hull damage taken by the player.
    public void HealPlayer(float Rate)
    {
        int HealCost = Mathf.RoundToInt((fl_HealthMax - fl_HealthCurrent) * Rate);
        if (fl_HealthCurrent < fl_HealthMax)
        {
            if(in_Credits > HealCost)
            {
                in_Credits -= HealCost;
                fl_HealthCurrent = fl_HealthMax;
                fl_ShieldCurrent = fl_ShieldMax;
            }
        }
    }
    public void SellCargo(float Rate)
    {
        int CargoValue = Mathf.RoundToInt(fl_CargoCurrent * Rate);
        fl_CargoCurrent = 0;
        in_Credits += CargoValue;
    }
    public void RefuelPlayer(float Rate)
    {
        int FuelCost = Mathf.RoundToInt((fl_FuelMax - fl_FuelMax) * Rate);
        if (fl_FuelCurrent < fl_FuelMax)
        {
            if (in_Credits > FuelCost)
            {
                in_Credits -= FuelCost;
                fl_FuelCurrent = fl_FuelMax;
            }
        }
    }
    public void MusicController(bool inBattle)
    {
        AudioSource musicplayer = GetComponent<AudioSource>();
        if (inBattle)
        {
            if(musicplayer.clip != Music[1])
            {
                musicplayer.clip = Music[1];
                musicplayer.Play();
            }
        }
        else
        {
            if (musicplayer.clip != Music[0])
            {
                musicplayer.clip = Music[0];
                musicplayer.Play();
            }
        }
    }
}
