using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounters : MonoBehaviour
{
    public float encounterTimer = 20.0f;
    public bool selectedGood = false;
    public bool selectedBad = false;
    float encountersFound = 0;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject encounterOptions1;
    public GameObject encounterOptions2;
    public GameObject encounterOptions3;
    public GameObject encounterOptions4;
    public GameObject encounterOptions5;
    public GameObject encounterOptions6;
    public GameObject encounterOptions7;
    public GameObject encounterOptions8;
    public GameObject encounterOptions9;
    public GameObject encounterOptions10;
    public GameObject encounterOptions11;
    public GameObject encounterOptions12;

    bool encounterActive = false;
    bool GW = false;
    bool BW = false;
    bool SP = false;
    bool WW = false;
    bool PV = false;
    bool FC = false;
    bool LL = false;
    bool DC = false;
    bool GL = false;
    bool AS = false;
    bool FS = false;
    bool WA = false;

    void Start()
    {
        encounterOptions1.gameObject.SetActive(false);
        encounterOptions2.gameObject.SetActive(false);
        encounterOptions3.gameObject.SetActive(false);
        encounterOptions4.gameObject.SetActive(false);
        encounterOptions5.gameObject.SetActive(false);
        encounterOptions6.gameObject.SetActive(false);
        encounterOptions7.gameObject.SetActive(false);
        encounterOptions8.gameObject.SetActive(false);
        encounterOptions9.gameObject.SetActive(false);
        encounterOptions10.gameObject.SetActive(false);
        encounterOptions11.gameObject.SetActive(false);
        encounterOptions12.gameObject.SetActive(false);
    }

    public void Update()
    {
        encounterTimer -= Time.deltaTime;
        
        if (encounterTimer <= 0 && !encounterActive)
        {
            player1.GetComponent<CharacterMovementScript>().enabled = false;
            player2.GetComponent<CharacterMovementScript>().enabled = false;
            player3.GetComponent<CharacterMovementScript>().enabled = false;
            player4.GetComponent<CharacterMovementScript>().enabled = false;//disables player movement
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
           if (totalTasks == 1 && dayCycle == 0)
            {
                BadWitch();
                BW = true;
                
            }
            if (totalTasks == 2 && dayCycle == 0)
            {
                SP = true;
                ShiningPool();
                
            }
            if (totalTasks == 3 && dayCycle == 0)
            {
                FungalCave();
                FC = true;

            }
            if (totalTasks == 0 && dayCycle == 1)
            {
                WW = true;
                Werewolf();

            }
            if (totalTasks == 1 && dayCycle == 1)
            {
                PixieVillage();
                PV = true;

            }
            if (totalTasks == 2 && dayCycle == 1)
            {
                WolfAttack();
                WA = true;

            }
            if (totalTasks == 3 && dayCycle == 1)
            {
                LostLibrary();
                LL = true;

            }
            if (totalTasks == 0 && dayCycle == 2)
            {
                FoxShrine();
                FS = true;

            }
            if (totalTasks == 1 && dayCycle == 2)
            {
                GnomeLord();
                GL = true;

            }
            if (totalTasks == 2 && dayCycle == 2)
            {
              AbandonedShack();
                AS = true;

            }
            if (totalTasks == 3 && dayCycle == 2)
            {
                GoodWitch();
                GW = true;

            }
            if (totalTasks == 0 && dayCycle == 3)
            {
                BadWitch();
                BW = true;

            }
            if (totalTasks == 1 && dayCycle == 3)
            {
                DarkCave();
                DC = true;

            }
            if (totalTasks == 2 && dayCycle == 3)
            {
                FungalCave();
                FC = true;

            }
            if (totalTasks == 3 && dayCycle == 3)
            {
                LostLibrary();
                LL = true;

            }
            if (totalTasks == 0 && dayCycle == 4)
            {
                PixieVillage();
                PV = true;

            }
            if (totalTasks == 1 && dayCycle == 4)
            {
                AbandonedShack();
                AS = true;

            }
            if (totalTasks == 2 && dayCycle == 4)
            {
                DarkCave();
                DC = true;

            }
            if (totalTasks == 3 && dayCycle == 4)
            {
               FoxShrine();
                FS = true;

            }
            if (totalTasks == 0 && dayCycle == 5)
            {
                FungalCave();
                FC = true;

            }
            if (totalTasks == 1 && dayCycle == 5)
            {
                LostLibrary();
                LL = true;

            }
            if (totalTasks == 2 && dayCycle == 5)
            {
                GnomeLord();
                GL = true;

            }
            if (totalTasks == 3 && dayCycle == 5)
            {
                DarkCave();
                DC = true;

            }
            if (totalTasks == 0 && dayCycle == 6)
            {
                Werewolf();
                WW = true;

            }
            if (totalTasks == 1 && dayCycle == 6)
            {
                FoxShrine();
                FS = true;

            }
            if (totalTasks == 2 && dayCycle == 6)
            {
                LostLibrary();
                LL = true;

            }
            if (totalTasks == 3 && dayCycle == 6)
            {
                WolfAttack();
                WA = true;

            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                selectedGood = true;
                Debug.Log("Selected True");
                encounterReward = encounterReward + 1;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                selectedBad = true;
                Debug.Log("Selected False");
                encounterReward = encounterReward - 1;
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
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
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
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true; //re-enables player movement
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
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
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
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
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
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            PV = false;
        }
        if (FC == true) //checks bool for encounter being over
        {
            if (FungalCave())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            FC = false;
        }
        if (DC == true) //checks bool for encounter being over
        {
            if (DarkCave())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            DC = false;
        }
        if (GL == true) //checks bool for encounter being over
        {
            if (GnomeLord())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            GL = false;
        }
        if (LL == true) //checks bool for encounter being over
        {
            if (LostLibrary())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            LL = false;
        }
        if (WA == true) //checks bool for encounter being over
        {
            if (WolfAttack())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            WA = false;
        }
        if (FS == true) //checks bool for encounter being over
        {
            if (FoxShrine())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            FS = false;
        }
        if (AS == true) //checks bool for encounter being over
        {
            if (AbandonedShack())
            {
                encounterActive = false; //deactivates Active loop
                encounterTimer = 100.0f; //resets timer
                encountersFound++;
                player1.GetComponent<CharacterMovementScript>().enabled = true;
                player2.GetComponent<CharacterMovementScript>().enabled = true;
                player3.GetComponent<CharacterMovementScript>().enabled = true;
                player4.GetComponent<CharacterMovementScript>().enabled = true;//re-enables player movement
            }
            AS = false;
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
    bool FungalCave()
    {
        bool retval5 = false;
        encounterOptions6.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions6.gameObject.SetActive(false);
            selectedGood = false;
            retval5 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions6.gameObject.SetActive(false);
            selectedBad = false;
            retval5 = true;
        }
        return retval5;
    }
    bool DarkCave()
    {
        bool retval6 = false;
        encounterOptions7.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions7.gameObject.SetActive(false);
            selectedGood = false;
            retval6 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions7.gameObject.SetActive(false);
            selectedBad = false;
            retval6 = true;
        }
        return retval6;
    }
    bool FoxShrine()
    {
        bool retval7 = false;
        encounterOptions8.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions8.gameObject.SetActive(false);
            selectedGood = false;
            retval7 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions8.gameObject.SetActive(false);
            selectedBad = false;
            retval7 = true;
        }
        return retval7;
    }
    bool GnomeLord()
    {
        bool retval8 = false;
        encounterOptions9.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions9.gameObject.SetActive(false);
            selectedGood = false;
            retval8 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions8.gameObject.SetActive(false);
            selectedBad = false;
            retval8 = true;
        }
        return retval8;
    }
    bool AbandonedShack()
    {
        bool retval9 = false;
        encounterOptions10.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions10.gameObject.SetActive(false);
            selectedGood = false;
            retval9 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions9.gameObject.SetActive(false);
            selectedBad = false;
            retval9 = true;
        }
        return retval9;
    }
    bool LostLibrary()
    {
        bool retval10 = false;
        encounterOptions11.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions11.gameObject.SetActive(false);
            selectedGood = false;
            retval10 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions11.gameObject.SetActive(false);
            selectedBad = false;
            retval10 = true;
        }
        return retval10;
    }
    bool WolfAttack()
    {
        bool retval11 = false;
        encounterOptions12.gameObject.SetActive(true);

        if (selectedGood == true)
        {
            encounterOptions12.gameObject.SetActive(false);
            selectedGood = false;
            retval11 = true;
        }
        else if (selectedBad == true)
        {
            encounterOptions12.gameObject.SetActive(false);
            selectedBad = false;
            retval11 = true;
        }
        return retval11;
    }
}
