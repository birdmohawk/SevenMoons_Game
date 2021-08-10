using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScavengeScript : MonoBehaviour
{
    public float nextSceneTime = 5;
    int clicks = 0;
    //public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseUpAsButton()
    {
        if (clicks >= 1)
        {
            GameOver();
            Debug.Log("clicked");
        }

        else clicks++;
    }

    private void GameOver()
    {
        nextSceneTime -= Time.deltaTime;
        //Debug.Log(score); //display score in UI!

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");
            SceneManager.LoadScene("Campsite");
        }
    }
}
