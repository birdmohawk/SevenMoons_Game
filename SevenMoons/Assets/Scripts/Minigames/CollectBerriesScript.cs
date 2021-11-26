using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectBerriesScript : MonoBehaviour
{
    public Transform[] spawnPos;

    public float nextSceneTime = 5;
    private bool  ended = false;
    public GameObject instructions;
    public GameObject endUI;
    public GameObject[] endUIOutcome;
    public GameObject[] berries;
    //[HideInInspector]
    public GameObject badBerry = null; //public so that they are accessible from CollectBerriesScript
    //[HideInInspector]
    public GameObject goodBerry = null; //public so that they are accessible from CollectBerriesScript

    // Start is called before the first frame update
    void Awake()
    {
        SpawnBerryPositions();

        foreach(GameObject obj in endUIOutcome) 
        {
            obj.SetActive(false);
        }

        GameManagerScript.gamemanager.TaskNumber();
        endUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse Clicked");
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit) //how to check hit goodberry/badberry?? - just randomise UI -___-
            {
                GameOver();
            }
        }
    }
    private void SpawnBerryPositions()
    {
        //1. Get the game manager to decide which berry type is bad, and which is good.
        GenerateBerries();
        //2. Position one of each, randomly at the spawn positions.
        //There's only ever 2 spawn positions, so 
        //  choose one randomly,
        //  make that the good berry, set it to active.
        //  make the other one the bad berry, set it to active.
        int randomPos1Index = UnityEngine.Random.Range(0, spawnPos.Length);
        //Set good berry to first random position.
        PositionAndEnableBerry(goodBerry,spawnPos[randomPos1Index].position);
        //Set second random index to whatever the first one WASNT
        int randomPos2Index = 0;
        if (randomPos1Index == randomPos2Index)
            randomPos2Index = 1;
        PositionAndEnableBerry(badBerry,spawnPos[randomPos2Index].position);

        Debug.Log("Good berry is at position: " + randomPos1Index);
        Debug.Log("Bad berry is at position: " + randomPos2Index);
    }

    public void DestroyBerries()
    {
        if (goodBerry != null)
            Destroy(goodBerry);
        if (badBerry != null)
            Destroy(badBerry);
        goodBerry = null;
        badBerry = null;
    }

    public void GenerateBerries() //generate berries is completed initially to keep consistent thruout game
    {
        DestroyBerries(); //Destroy berries if they exist
        Debug.Log("Berries Generated");
        int badBerryIndex = UnityEngine.Random.Range(0, berries.Length); //pick a number between 0 and len-1
        //If there are only ever two berries to pick, then don't let them be the same.
        int goodBerryIndex = badBerryIndex;
        while (goodBerryIndex == badBerryIndex && (berries.Length > 1))
        {
            goodBerryIndex = UnityEngine.Random.Range(0, berries.Length); //pick a number between 0 and len-1
        }
        goodBerry = Instantiate(berries[goodBerryIndex]);
        badBerry = Instantiate(berries[badBerryIndex]);
        goodBerry.gameObject.SetActive(false);
        badBerry.gameObject.SetActive(false);

        //So, at the end, we should have a good berry and a bad berry that are different berries from the berries array.
        //These are both instantiated, and hidden.
    }
    public void PositionAndEnableBerry(GameObject berry, Vector2 pos)
    {
        berry.transform.position = pos;
        berry.SetActive(true);
    }
    private void GameOver()
    {
        //Debug.Log("GameOver");
        badBerry.gameObject.SetActive(false);
        goodBerry.gameObject.SetActive(false);
        instructions.SetActive(false);

        endUI.SetActive(true);
        
        if (!ended)
        {
            ended = true;
            int index = UnityEngine.Random.Range(0, endUIOutcome.Length);
            endUIOutcome[index].SetActive(true);

            if (endUIOutcome[index].tag == "good")
            {
                GameManagerScript.gamemanager.BestScore();
                Debug.Log("score is good");
            }

            else
            {
                GameManagerScript.gamemanager.BadScore();
                Debug.Log("score is bad");
            }
        }
    }
}
