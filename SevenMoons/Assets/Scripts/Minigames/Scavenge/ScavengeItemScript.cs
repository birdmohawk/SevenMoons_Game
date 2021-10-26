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
    public TMP_Text displayTotal;

    public float timePassed;

    public GameObject bestGameUI;
    public GameObject goodGameUI;
    public GameObject badGameUI;
    public GameObject endGameUI;

    void Awake()
    {
        endGameUI.gameObject.SetActive(false);
        bestGameUI.gameObject.SetActive(false);
        goodGameUI.gameObject.SetActive(false);
        badGameUI.gameObject.SetActive(false);
    }

    void Start()
    {
        endGameUI.gameObject.SetActive(false);
        GameManagerScript.gamemanager.TaskNumber();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggers <= 0)
        {
            //Debug.Log("game over");
            GameOver();
        }

        else 
        {
            endGameUI.gameObject.SetActive(false); //trying this to avoid scavenge bug for now >:(
            instructions.gameObject.SetActive(true);
            displayTotal.text = "";
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

        if (timePassed <= 15)
        {
            Debug.Log("great score!");
            //GameManagerScript.gamemanager.BestScore();
            bestGameUI.gameObject.SetActive(true);
        }

        else if (timePassed > 15 && timePassed < 30)
        {
            Debug.Log("good score!");
            //GameManagerScript.gamemanager.GoodScore();
            goodGameUI.gameObject.SetActive(true);
        }

        else 
        {
            Debug.Log("bad score!");
            //GameManagerScript.gamemanager.BadScore();
            badGameUI.gameObject.SetActive(true);
        }
    }
}
