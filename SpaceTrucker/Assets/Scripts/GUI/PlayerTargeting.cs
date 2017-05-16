using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTargeting : MonoBehaviour {
    //Player Targetting
    public GameObject[] targetObjects;
    public int targetIndex = 0;
    public TargetInformation TargetData;
    public GameObject Player;
    //UI elements
    public Text TargetName;
    public Text TargetDistance;
    public Text TargetInfo;
    //Interaction
    public float InteractionDistance;
    public GameObject InteractMenu;
    public Text InteractText;
    public string InteractString = "Press Interact to ";

	// Use this for initialization
	void Start () {
        TargetName.text = TargetDistance.text = TargetInfo.text = InteractText.text = "";
        TargetInfo.text = "Initialising Geo-centric Non-hostile Object Manage Engine, Please hold";
        TargetData = targetObjects[targetIndex].GetComponent<TargetInformation>();
        StartCoroutine(SystemLoading(5));
        TargetInfo.text = "G.N.O.M.E. Initialised.";
        StartCoroutine(SystemLoading(3));

	}
	
	// Update is called once per frame
	void Update () {
        //Set up the data
        TargetData = targetObjects[targetIndex].GetComponent<TargetInformation>();
        TargetName.text = TargetData.Name;
        TargetDistance.text = "Aprox: "+ Mathf.RoundToInt(Vector3.Distance(Player.transform.position, targetObjects[targetIndex].transform.position)) + " units away";
        TargetInfo.text = TargetData.Information;
        Interact();
        if(Input.GetButtonDown("NextTarget"))
        {
            TargetSelect(true);
        }
        if(Input.GetButtonDown("PreviousTarget"))
        {
            TargetSelect(false);
        }

    }
    //The target changing options. Encapsulating a loop around so that if the target is at the end of the array, it loops back to the first
    //and vice versa. Also encapsulates both next and previous with the boolean.
    void TargetSelect(bool next)
    {
        if(next)
        {
            if(targetIndex == targetObjects.Length-1)
            {
                targetIndex = 0;
            }
            else
            {
                targetIndex++;
            }
        }
        else
        {
            if(targetIndex == 0)
            {
                targetIndex = targetObjects.Length-1;
            }
            else
            {
                targetIndex--;
            }
        }
    }
    void Interact()//Interacting with the target.
    {
        if(Vector3.Distance(Player.transform.position, targetObjects[targetIndex].transform.position) <= InteractionDistance)//check the target is in range
        {
            //Interact menu to active!
            InteractMenu.SetActive(true);
            if(Input.GetButton("Interact"))//On player pressing the interact button
            {
                Debug.Log("Interact Pressed");
                TargetData.Interaction(Player);//Run this.
            }
        }
        else
        {
            InteractMenu.SetActive(false);//if out of range, disable the UI element.
        }
    }
    //Frill.
    IEnumerator SystemLoading(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
    }
}
