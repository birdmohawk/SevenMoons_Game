using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    /* this script is used to store data that needs to be consistent thru one play thru of the game
     * this includes data such as STATS, day and night cycles, number of tasks*/

    public static GameManagerScript gamemanager;

    public int tasks;
    int nights;

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
        Debug.Log(tasks);
    }
    
    public void EndofDay()
    {
        tasks = 0;
        nights++;
        Debug.Log("Day number" + nights);
        //Debug.Log("end of day narrative");
        SceneManager.LoadScene("Day 1 Night");
    }
}
