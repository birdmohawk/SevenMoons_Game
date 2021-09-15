using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckScript : MonoBehaviour
{
    //public static TaskCheckScript taskcheckscript;

    public GameObject player1; //Artemis
    public GameObject player2; //Hapi
    public GameObject player3; //Griffin
    public GameObject player4; //Albert

    void Awake()
    {
        NextTurn();
    }

    void Update()
    {
        
    }

    public void NextTurn()
    {
        int totalTasks = GameManagerScript.gamemanager.tasks;

        if (totalTasks == 0)
        {
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(false);
            player3.gameObject.SetActive(false);
            player4.gameObject.SetActive(false);
            Debug.Log("player 1 turn");
        }
        
        if (totalTasks == 1)
        {
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(true);
            player3.gameObject.SetActive(false);
            player4.gameObject.SetActive(false);
            Debug.Log("player 2 turn");
        }

        if (totalTasks == 2)
        {
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);
            player3.gameObject.SetActive(true);
            player4.gameObject.SetActive(false);
            Debug.Log("player 3 turn");
        }

        if (totalTasks == 3)
        {
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);
            player3.gameObject.SetActive(false);
            player4.gameObject.SetActive(true);
            Debug.Log("player 4 turn");
        }

        else if (totalTasks >=4)
        {
            GameManagerScript.gamemanager.EndofDay();
        }
    }
}
