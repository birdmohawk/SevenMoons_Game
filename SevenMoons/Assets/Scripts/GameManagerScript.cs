using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    /* this script is used to store data that needs to be consistent thru one play thru of the game
     * this includes data such as STATS, good + bad berry types*/

    public static GameManagerScript gamemanager;

    public GameObject[] berries;
    public static GameObject badBerry; //static so that they are accessible from CollectBerriesScript
    public static GameObject goodBerry; //static so that they are accessible from CollectBerriesScript

    //STATS here 

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
        GenerateBerries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateBerries() //generate berries is completed initially to keep consistent thruout game
    {
        Debug.Log("Berries Generated");
        int randomBerries = UnityEngine.Random.Range(1, berries.Length); //set to 1 so that Good + Bad berries are always different and stay within array bounds. need to change to random

        GameObject randomBerryBad = berries[randomBerries];
        badBerry = randomBerryBad;

        GameObject randomBerryGood = berries[randomBerries - 1];
        goodBerry = randomBerryGood;


    }
}
