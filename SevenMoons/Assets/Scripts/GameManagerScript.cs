using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    /* this script is used to store data that needs to be consistent thru one play thru of the game
     * this includes data such as STATS, good + bad berry types*/

    public static GameManagerScript gamemanager;

    public GameObject[] berries;
    [HideInInspector]
    public GameObject badBerry = null; //public so that they are accessible from CollectBerriesScript
    [HideInInspector]
    public GameObject goodBerry = null; //public so that they are accessible from CollectBerriesScript

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

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
