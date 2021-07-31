using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectBerriesScript : MonoBehaviour
{
    public float nextSceneTime = 5;

    public Transform spawnPositionOne;
    public Transform spawnPositionTwo;

    //public GameObject []berries; //moved to GameManagerScript to keep berries consistent thruout gameplay

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(GoodBerry, spawnPositionOne.transform);
        //Instantiate(berries[2], spawnPositionTwo.transform);
    }

    private void GameOver()
    {
        nextSceneTime -= Time.deltaTime;
        Debug.Log("GameOver");

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");
            SceneManager.LoadScene("Campsite");
        }
    }
}
