using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    /* this script is used to store data that needs to be consistent thru one play thru of the game
     * this includes data such as STATS, good + bad berry types*/

    public static GameManagerScript gamemanager;

    //STATS here 
    public GameObject player1; //Artemis
    public GameObject player2; //Hapi
    public GameObject player3; //Griffin
    public GameObject player4; //Albert

    public int tasks;
    int prevTasks;
    int totalTasks;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); //keeps GameManagerScript thruout all scenes

        if (gamemanager == null)
        {
            gamemanager = this;
        }

        else if (gamemanager != this)
        {
            Destroy(gameObject); //destroys duplicates of script. This is important to avoid a duplicate in the Campsite scene (original scene with GameManager in the scene)
        }

        /*player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(true);
        player3.gameObject.SetActive(true);
        player4.gameObject.SetActive(false);*/
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void TaskNumber()
    {
        tasks++;
        prevTasks = totalTasks;
    }

    public void TotalTasks()
    {
        totalTasks = prevTasks + tasks;
        Debug.Log(totalTasks);

        if (totalTasks >= 1)
        {
            player1.gameObject.SetActive(false);
            player4.gameObject.SetActive(true);

            player3.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);
            Debug.Log("next player");
        }

        else
        {
            player1.gameObject.SetActive(true);
            player4.gameObject.SetActive(false);

            player3.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);
        }
    }
}
