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
    public int nights;

    /* STATS */
    public int artemisPoints; 
    public int hapiPoints;
    public int griffinPoints;
    public int albertPoints;
    public int totalPoints;

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

    public void BestScore()
    {
        if (tasks == 1)
        {
            artemisPoints = artemisPoints + 3;
        }

        if (tasks == 2)
        {
            hapiPoints = hapiPoints + 3;
        }

        if (tasks == 3)
        {
            griffinPoints = griffinPoints + 3;
        }

        if (tasks == 4)
        {
            albertPoints = albertPoints + 3;
        }
    }

    public void GoodScore()
    {
        if (tasks == 1)
        {
            artemisPoints = artemisPoints + 1;
        }

        if (tasks == 2)
        {
            hapiPoints = hapiPoints + 1;
        }

        if (tasks == 3)
        {
            griffinPoints = griffinPoints + 1;
        }

        if (tasks == 4)
        {
            albertPoints = albertPoints + 1;
        }
    }

    public void BadScore()
    {
        if (tasks == 1)
        {
            artemisPoints = artemisPoints - 1;
        }

        if (tasks == 2)
        {
            hapiPoints = hapiPoints - 1;
        }

        if (tasks == 3)
        {
            griffinPoints = griffinPoints - 1;
        }

        if (tasks == 4)
        {
            albertPoints = albertPoints - 1;
        }
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

        if (nights == 1)
        {
            SceneManager.LoadScene("Day 1 Night");
        }

        if (nights == 2)
        {
            SceneManager.LoadScene("Day 2 Night");
        }

        if (nights == 3)
        {
            SceneManager.LoadScene("Day 3 Night");
        }

        if (nights == 4)
        {
            SceneManager.LoadScene("Day 4 Night");
        }

        if (nights == 5)
        {
            SceneManager.LoadScene("Day 5 Night");
        }

        if (nights == 6)
        {
            SceneManager.LoadScene("Day 6 Night");
        }
        
        if (nights == 7)
        {
            if (artemisPoints + griffinPoints + albertPoints + hapiPoints + totalPoints > 80)
            {
                SceneManager.LoadScene ("EndScene1");
            }
            if (artemisPoints + griffinPoints + albertPoints + hapiPoints + totalPoints < 40)
            {
                SceneManager.LoadScene ("EndScene3");
            }
            else
            {
                SceneManager.LoadScene ("EndScene2");
            }
            
        }
    }
}
