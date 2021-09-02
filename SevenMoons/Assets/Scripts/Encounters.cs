using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounters : MonoBehaviour
{
    private bool active = false;
    public GameObject player;
    public GameObject encounterInfo;
    public GameObject encounterOptions1;
    public GameObject encounterOptions2;
    public GameObject encounterOptions3;

    void Start()
    {
        encounterInfo.gameObject.SetActive(false);
        encounterOptions1.gameObject.SetActive(false);
        encounterOptions2.gameObject.SetActive(false);
        encounterOptions3.gameObject.SetActive(false);
    }

    public void Update()
    {
        CheckForEncounters();

        if (active = true)
        {
            Debug.Log("Encounter detected");
            //EncounterCheck();
            active = false;
        }
    }
    
    private void CheckForEncounters()
    {
        if (player.gameObject.transform.position != null)
        {
            if (Random.Range(1, 10000) <= 1)
            {
                active = true;
            }
        }
    }

    public void EncounterCheck()
    {
        if (Random.Range(1,10) <= 3)
        {
            GoodWitch();
        }
        else if (Random.Range (1,10) <= 6)
        {
            BadWitch();
        }
        else if (Random.Range (1,10) <= 10)
        {
            ShiningPool();
        }
    }
    
    void GoodWitch()
    {
        encounterInfo.gameObject.SetActive(true);
        encounterOptions1.gameObject.SetActive(true);

        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Stat upgraded");
            encounterInfo.gameObject.SetActive(false);
            encounterOptions1.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("space"))
        {
            Debug.Log("Stat Downgraded");
            encounterInfo.gameObject.SetActive(false);
            encounterOptions1.gameObject.SetActive(false);
        }

    }

    void BadWitch()
    {
        encounterInfo.gameObject.SetActive(true);
        encounterOptions2.gameObject.SetActive(true);

        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Stat upgraded");
            encounterInfo.gameObject.SetActive(false);
            encounterOptions2.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("space"))
        {
            Debug.Log("Stat Downgraded");
            encounterInfo.gameObject.SetActive(false);
            encounterOptions2.gameObject.SetActive(false);
        }
    }

    void ShiningPool()
    {
       encounterInfo.gameObject.SetActive(true);
       encounterOptions3.gameObject.SetActive(true);
        
        if (Input.GetKeyDown("up"))
        {
          Debug.Log("Stat upgraded");
          encounterInfo.gameObject.SetActive(false);
          encounterOptions3.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("space"))
        {
          Debug.Log("Stat Downgraded");
          encounterInfo.gameObject.SetActive(false);
          encounterOptions3.gameObject.SetActive(false);
        }
    }
    
}
    