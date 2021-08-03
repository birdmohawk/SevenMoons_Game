using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectBerriesScript : MonoBehaviour
{
    public float nextSceneTime = 5;

    public Transform[] spawnPos;

    // Start is called before the first frame update
    void Start()
    {
  
        SpawnBerryPositions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnBerryPositions()
    {
        //1. Get the game manager to decide which berry type is bad, and which is good.
        GameManagerScript.gamemanager.GenerateBerries();
        //2. Position one of each, randomly at the spawn positions.
        //There's only ever 2 spawn positions, so 
        //  choose one randomly,
        //  make that the good berry, set it to active.
        //  make the other one the bad berry, set it to active.
        int randomPos1Index = UnityEngine.Random.Range(0, spawnPos.Length);
        //Set good berry to first random position.
        GameManagerScript.gamemanager.PositionAndEnableBerry(GameManagerScript.gamemanager.goodBerry, 
                                                             spawnPos[randomPos1Index].position);
        //Set second random index to whatever the first one WASNT
        int randomPos2Index = 0;
        if (randomPos1Index == randomPos2Index)
            randomPos2Index = 1;
        GameManagerScript.gamemanager.PositionAndEnableBerry(GameManagerScript.gamemanager.badBerry, 
                                                             spawnPos[randomPos2Index].position);

        Debug.Log("Good berry is at position: " + randomPos1Index);
        Debug.Log("Bad berry is at position: " + randomPos2Index);
        
    }

    private void GameOver()
    {
        nextSceneTime -= Time.deltaTime;
        Debug.Log("GameOver");

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");*
            SceneManager.LoadScene("Campsite");
        }
    }

}
