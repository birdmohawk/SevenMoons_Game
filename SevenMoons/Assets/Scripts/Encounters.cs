using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounters : MonoBehaviour
{
    public float encounterTimer = 10.0f;
    public bool selectedGood = false;
    public bool selectedBad = false;

    public GameObject player;
    public GameObject encounterInfo;
    public GameObject encounterOptions1;
    public GameObject encounterOptions2;
    public GameObject encounterOptions3;
    /*public GameObject encounterOptions4;
    public GameObject encounterOptions5;
    public GameObject encounterOptions6;
    public GameObject encounterOptions7;
    public GameObject encounterOptions8;
    public GameObject encounterOptions9;*/

    bool encounterActive = false;

    void Start()
    {
        encounterInfo.gameObject.SetActive(false);
        encounterOptions1.gameObject.SetActive(false);
        encounterOptions2.gameObject.SetActive(false);
        encounterOptions3.gameObject.SetActive(false);
    }

    public void Update()
    {
        encounterTimer -= Time.deltaTime;
        
        if (encounterTimer <= 0 && !encounterActive)
        {
            player.GetComponent<CharacterMovementScript>().enabled = false; //disables player movement
            Debug.Log("Encounter detected");
            encounterActive = true; //Is designed to keep update loop not redoing or overdo it 
            
        }

        if (encounterActive) //encounterActive is true and constantly checking for the button presses
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                selectedGood = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedBad = true;
            }
            
            EncounterCheck();
            
        }
    }
    
    public void OnGoodButtonPress() //for later when checking button presses
    {
        selectedGood = true;
        selectedBad = false;
    }

    public void OnBadButtonPress()
    {
        selectedBad = true;
        selectedGood = false;
    }

    public void EncounterCheck()
    {
       if ( GoodWitch() ) //checks bool for encounter being over
        {
            encounterActive = false; //deactivates Active loop
            encounterTimer = 100.0f; //resets timer
            player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
        }
        /*if (BadWitch()) //checks bool for encounter being over
        {
            encounterActive = false; //deactivates Active loop
            encounterTimer = 100.0f; //resets timer
            player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
        }
        if (ShiningPool()) //checks bool for encounter being over
        {
            encounterActive = false; //deactivates Active loop
            encounterTimer = 100.0f; //resets timer
            player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
        }*/
    }
    
    bool GoodWitch()
    {
        bool retval = false;
        encounterInfo.gameObject.SetActive(true);
        encounterOptions1.gameObject.SetActive(true);
        encounterOptions2.gameObject.SetActive(true);
        encounterOptions3.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterInfo.gameObject.SetActive(false);
            encounterOptions1.gameObject.SetActive(false);
            encounterOptions2.gameObject.SetActive(false);
            encounterOptions3.gameObject.SetActive(false);
            selectedGood = false; //return stats here
            retval = true;
        }
        else if (selectedBad == true)
        {
            encounterInfo.gameObject.SetActive(false);
            encounterOptions1.gameObject.SetActive(false);
            encounterOptions2.gameObject.SetActive(false);
            encounterOptions3.gameObject.SetActive(false);
            selectedBad = false;// return stats here
            retval = true;
        }
        return retval; //returns retval values
    }

 

    /*bool BadWitch()
    {
        bool retval = false;
        encounterInfo.gameObject.SetActive(true);
        encounterOptions4.gameObject.SetActive(true);
        encounterOptions5.gameObject.SetActive(true);
        encounterOptions6.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterInfo.gameObject.SetActive(false);
            encounterOptions4.gameObject.SetActive(false);
            encounterOptions5.gameObject.SetActive(false);
            encounterOptions6.gameObject.SetActive(false);
            selectedGood = false;
            retval = true;
        }
        else if (selectedBad == true)
        {
            encounterInfo.gameObject.SetActive(false);
            encounterOptions4.gameObject.SetActive(false);
            encounterOptions5.gameObject.SetActive(false);
            encounterOptions6.gameObject.SetActive(false);
            selectedBad = false;
            retval = true;
        }
        return retval;
    }

    bool ShiningPool()
    {
      bool retval = false;
        encounterInfo.gameObject.SetActive(true);
        encounterOptions7.gameObject.SetActive(true);
        encounterOptions8.gameObject.SetActive(true);
        encounterOptions9.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterInfo.gameObject.SetActive(false);
            encounterOptions7.gameObject.SetActive(false);
            encounterOptions8.gameObject.SetActive(false);
            encounterOptions9.gameObject.SetActive(false);
            selectedGood = false;
            retval = true;
        }
        else if (selectedBad == true)
        {
            encounterInfo.gameObject.SetActive(false);
            encounterOptions7.gameObject.SetActive(false);
            encounterOptions8.gameObject.SetActive(false);
            encounterOptions9.gameObject.SetActive(false);
            selectedBad = false;
            retval = true;
        }
        return retval;
    }*/

}
