using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckScript : MonoBehaviour
{
    public GameObject Artemis; //Artemis
    public GameObject Hapi; //Hapi
    public GameObject Griffin; //Griffin
    public GameObject Albert; //Albert

    public GameObject Artemis_Idle; //Artemis
    public GameObject Hapi_Idle; //Hapi
    public GameObject Griffin_Idle; //Griffin
    public GameObject Albert_Idle; //Albert

    /* MOON UI INDICATES TURNS */    
    public GameObject firstQuarter; //Artemis
    public GameObject secondQuarter; //Hapi
    public GameObject thirdQuarter; //Griffin
    public GameObject fourthQuarter; //Albert 

    /*void Start()
    {
        NextTurn();
        Debug.Log("Artemis points are " + GameManagerScript.gamemanager.artemisPoints);
        Debug.Log("Hapi points are " + GameManagerScript.gamemanager.hapiPoints);
        Debug.Log("Griffin points are " + GameManagerScript.gamemanager.griffinPoints);
        Debug.Log("Albert points are " + GameManagerScript.gamemanager.albertPoints);

        TimeOfDay();
    }*/

    void Awake()
    {
        NextTurn();
        Debug.Log("Artemis points are " + GameManagerScript.gamemanager.artemisPoints);
        Debug.Log("Hapi points are " + GameManagerScript.gamemanager.hapiPoints);
        Debug.Log("Griffin points are " + GameManagerScript.gamemanager.griffinPoints);
        Debug.Log("Albert points are " + GameManagerScript.gamemanager.albertPoints);

        TimeOfDay();

        //manager.GetComponent<PostWwiseEvent>().StopSound2();
    }

    void Update()
    {
        
    }

    public void NextTurn()
    {
        int totalTasks = GameManagerScript.gamemanager.tasks;

        if (totalTasks == 0)
        {
            Artemis.gameObject.SetActive(true);
            Hapi.gameObject.SetActive(false);
            Griffin.gameObject.SetActive(false);
            Albert.gameObject.SetActive(false);
            Debug.Log("player 1 turn");

            Artemis_Idle.gameObject.SetActive(false);
            Hapi_Idle.gameObject.SetActive(true);
            Griffin_Idle.gameObject.SetActive(true);
            Albert_Idle.gameObject.SetActive(true);
        }
        
        if (totalTasks == 1)
        {
            Artemis.gameObject.SetActive(false);
            Hapi.gameObject.SetActive(true);
            Griffin.gameObject.SetActive(false);
            Albert.gameObject.SetActive(false);
            Debug.Log("player 2 turn");

            Artemis_Idle.gameObject.SetActive(true);
            Hapi_Idle.gameObject.SetActive(false);
            Griffin_Idle.gameObject.SetActive(true);
            Albert_Idle.gameObject.SetActive(true);
        }

        if (totalTasks == 2)
        {
            Artemis.gameObject.SetActive(false);
            Hapi.gameObject.SetActive(false);
            Griffin.gameObject.SetActive(true);
            Albert.gameObject.SetActive(false);
            Debug.Log("player 3 turn");

            Artemis_Idle.gameObject.SetActive(true);
            Hapi_Idle.gameObject.SetActive(true);
            Griffin_Idle.gameObject.SetActive(false);
            Albert_Idle.gameObject.SetActive(true);
        }

        if (totalTasks == 3)
        {
            Artemis.gameObject.SetActive(false);
            Hapi.gameObject.SetActive(false);
            Griffin.gameObject.SetActive(false);
            Albert.gameObject.SetActive(true);
            Debug.Log("player 4 turn");

            Artemis_Idle.gameObject.SetActive(true);
            Hapi_Idle.gameObject.SetActive(true);
            Griffin_Idle.gameObject.SetActive(true);
            Albert_Idle.gameObject.SetActive(false);
        }

        else if (totalTasks >=4) 
        {
            GameManagerScript.gamemanager.EndofDay();
        }
    }

    public void TimeOfDay()
    {
        int totalTasks = GameManagerScript.gamemanager.tasks;

        if (totalTasks == 0)
        {
            firstQuarter.gameObject.SetActive(true);
            secondQuarter.gameObject.SetActive(false);
            thirdQuarter.gameObject.SetActive(false);
            fourthQuarter.gameObject.SetActive(false);
        }

        if (totalTasks == 1)
        {
            firstQuarter.gameObject.SetActive(false);
            secondQuarter.gameObject.SetActive(true);
            thirdQuarter.gameObject.SetActive(false);
            fourthQuarter.gameObject.SetActive(false);
        }

        if (totalTasks == 2)
        {
            firstQuarter.gameObject.SetActive(false);
            secondQuarter.gameObject.SetActive(false);
            thirdQuarter.gameObject.SetActive(true);
            fourthQuarter.gameObject.SetActive(false);
        }

        if (totalTasks == 3)
        {
            firstQuarter.gameObject.SetActive(false);
            secondQuarter.gameObject.SetActive(false);
            thirdQuarter.gameObject.SetActive(false);
            fourthQuarter.gameObject.SetActive(true);
        }
    }
}
