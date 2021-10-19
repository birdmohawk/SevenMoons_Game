using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounters : MonoBehaviour
{
    public float encounterTimer = 10.0f;
    public bool selectedGood = false;
    public bool selectedBad = false;
    float encountersFound = 0;

    public GameObject player;
    public GameObject encounterOptions1;
    public GameObject encounterOptions2;
    public GameObject encounterOptions3;
    public GameObject encounterOptions4;
    public GameObject encounterOptions5;
    public GameObject encounterOptions6;
    public GameObject encounterOptions7;
    public GameObject encounterOptions8;
    public GameObject encounterOptions9;

    bool encounterActive = false;
    bool GW = false;
    bool BW = false;
    bool SP = false;
    bool WW = false;
    bool PV = false;

    void Start()
    {
        encounterOptions1.gameObject.SetActive(false);
        encounterOptions2.gameObject.SetActive(false);
        encounterOptions3.gameObject.SetActive(false);
        encounterOptions4.gameObject.SetActive(false);
        encounterOptions5.gameObject.SetActive(false);
        encounterOptions6.gameObject.SetActive(false);
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
            int encounterReward = GameManagerScript.gamemanager.totalPoints;
            int totalTasks = GameManagerScript.gamemanager.tasks;
            int dayCycle = GameManagerScript.gamemanager.nights;

            if (totalTasks == 0 && dayCycle == 0)
            {
                GoodWitch();
                GW = true;
                
            }
           if (totalTasks == 1)
            {
                BadWitch();
                BW = true;
                
            }
            if (totalTasks == 2)
            {
                SP = true;
                ShiningPool();
                
            }
            if (totalTasks == 3)
            {
                WW = true;
                Werewolf();

            }
            if (totalTasks == 0 && dayCycle == 1)
            {
               PixieVillage();
                PV = true;

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                selectedGood = true;
                Debug.Log("Selected True");
                encounterReward++;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedBad = true;
                Debug.Log("Selected False");
                encounterReward--;
            }

            EncounterCheck();
        }
    }

    public void EncounterCheck()
    {
        if (GW == true) //checks bool for encounter being over
        {
            if(GoodWitch())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
            }
            GW = false;
        }
        
        if (BW == true) //checks bool for encounter being over
        {
            if(BadWitch())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
            }
            BW = false;
        }
       
        if (SP == true) //checks bool for encounter being over
        {
            if(ShiningPool())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
            }
            SP = false;
        }
        if (WW == true) //checks bool for encounter being over
        {
            if (Werewolf())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
            }
            WW = false;
        }
        if (PV == true) //checks bool for encounter being over
        {
            if (PixieVillage())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
            }
            PV = false;
        }
    }

        
    
    bool GoodWitch()
    {
        bool retval = false;
        encounterOptions1.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions1.gameObject.SetActive(false);
            selectedGood = false; //return stats here
            retval = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions1.gameObject.SetActive(false);
            selectedBad = false;// return stats here
            retval = true;
        }
        return retval; //returns retval values
    }

     bool BadWitch()
    {
        bool retval1 = false;
        encounterOptions2.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions2.gameObject.SetActive(false);
            selectedGood = false;
            retval1 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions2.gameObject.SetActive(false);
            selectedBad = false;
            retval1 = true;
        }
        return retval1;
    }

    bool ShiningPool()
    {
      bool retval2 = false;
        encounterOptions3.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions3.gameObject.SetActive(false);
            selectedGood = false;
            retval2 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions3.gameObject.SetActive(false);
            selectedBad = false;
            retval2 = true;
        }
        return retval2;
    }
    bool Werewolf()
    {
        bool retval3 = false;
        encounterOptions4.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions4.gameObject.SetActive(false);
            selectedGood = false;
            retval3 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions4.gameObject.SetActive(false);
            selectedBad = false;
            retval3 = true;
        }
        return retval3;
    }
    bool PixieVillage()
    {
        bool retval4 = false;
        encounterOptions5.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions5.gameObject.SetActive(false);
            selectedGood = false;
            retval4 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions5.gameObject.SetActive(false);
            selectedBad = false;
            retval4 = true;
        }
        return retval4;
    }
}
