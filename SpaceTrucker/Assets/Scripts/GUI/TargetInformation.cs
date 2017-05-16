using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetInformation : MonoBehaviour {
    public string Information;
    public string Name;
    public string InteractionMethod;
    public enum InteractionType
    {
        Heal,
        Trade,
        Refuel
    }
    public InteractionType Type;
    public float ServiceRate;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Interaction(GameObject Player)
    {
        PlayerScript sc_script = Player.GetComponent<PlayerScript>();
        if(Type == InteractionType.Heal)
        {
            //Heal the player.
            sc_script.HealPlayer(ServiceRate);
            
        }
        else if(Type ==InteractionType.Trade)
        {
            sc_script.SellCargo(ServiceRate);
        }
        else if(Type == InteractionType.Refuel)
        {
            sc_script.RefuelPlayer(ServiceRate);
        }
    }
}
