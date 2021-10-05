using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckScript : MonoBehaviour
{
    //public static TaskCheckScript taskcheckscript;
    public GameObject Artemis; //Artemis
    public GameObject Hapi; //Hapi
    public GameObject Griffin; //Griffin
    public GameObject Albert; //Albert

    public GameObject Artemis_Idle; //Artemis
    public GameObject Hapi_Idle; //Hapi
    public GameObject Griffin_Idle; //Griffin
    public GameObject Albert_Idle; //Albert

    void Awake()
    {
        NextTurn();
        Debug.Log("Artemis points are " + GameManagerScript.gamemanager.artemisPoints);
        Debug.Log("Hapi points are " + GameManagerScript.gamemanager.hapiPoints);
        Debug.Log("Griffin points are " + GameManagerScript.gamemanager.griffinPoints);
        Debug.Log("Albert points are " + GameManagerScript.gamemanager.albertPoints);
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
}
