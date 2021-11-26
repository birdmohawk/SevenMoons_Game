using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScavengeItemScript : MonoBehaviour
{
    public int triggers;

    public GameObject instructions;

    public float timePassed;
    public float startTime;

    public GameObject endGameUI;
    public GameObject[] bestGameUI;
    public GameObject[] goodGameUI;
    public GameObject[] badGameUI;

    private bool ended = false;

    void Awake()
    {
        endGameUI.gameObject.SetActive(false);
        foreach (GameObject obj in bestGameUI)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in goodGameUI)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in badGameUI)
        {
            obj.SetActive(false);
        }
    }

    void Start()
    {
        endGameUI.gameObject.SetActive(false);
        GameManagerScript.gamemanager.TaskNumber();
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;

        if (triggers <= 0 && startTime <= 0)
        {
            //Debug.Log("game over");
            GameOver();
        }

        else 
        {
            endGameUI.gameObject.SetActive(false); //trying this to avoid scavenge bug for now >:(
            instructions.gameObject.SetActive(true);
            timePassed += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("items");
        triggers++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("no items");
        triggers--;
    }

    void GameOver()
    {
        endGameUI.gameObject.SetActive(true);
        instructions.gameObject.SetActive(false);

        if (!ended)
        {
            ended = true;

            if (timePassed <= 15)
            {
                //Debug.Log("great score!");
                int index = UnityEngine.Random.Range(0, bestGameUI.Length);
                bestGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.BestScore();
            }

            else if (timePassed > 15 && timePassed < 35)
            {
                //Debug.Log("good score!");
                int index = UnityEngine.Random.Range(0, goodGameUI.Length);
                goodGameUI[2].SetActive(true);
                GameManagerScript.gamemanager.GoodScore();
            }

            else
            {
                //Debug.Log("bad score!");
                int index = UnityEngine.Random.Range(0, badGameUI.Length);
                badGameUI[1].SetActive(true);
                GameManagerScript.gamemanager.BadScore();
            }
        }
    }
}
