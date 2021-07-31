using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript gamemanager;

    public GameObject[] berries;
    public GameObject badBerry;
    public GameObject goodBerry;

    //store STATS here 

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (gamemanager == null)
        {
            gamemanager = this;
        }

        else if (gamemanager != this)
        {
            Destroy(gameObject);
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

    public void GenerateBerries()
    {
        Debug.Log("Berries Generated");
        int randomBerries = UnityEngine.Random.Range(1, berries.Length);
        GameObject randomBerryBad = berries[randomBerries];
        badBerry = randomBerryBad;


        GameObject randomBerryGood = berries[randomBerries -1];
        goodBerry = randomBerryGood;
    }
}
