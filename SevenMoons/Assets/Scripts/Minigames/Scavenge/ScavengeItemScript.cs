using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScavengeItemScript : MonoBehaviour
{
    public int triggers;

    public GameObject endGameUI;
    public GameObject instructions;
    public TMP_Text displayTotal;

    public float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        endGameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (triggers <= 0)
        {
            Debug.Log("game over");
            GameOver();
        }

        timePassed += Time.deltaTime;
    }

    void OnMouseDown()
    {
        //Debug.Log("book clicked");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("items");
        triggers++;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("no items");
        triggers--;
    }

    void GameOver()
    {
        endGameUI.gameObject.SetActive(true);
        instructions.gameObject.SetActive(false);
        displayTotal.text = "Great Job";

        /*if (timePassed <= 8)
        {
            Debug.Log("good score!");
        }
        
        if (timePassed > 8)
        {
            Debug.Log("bad score!");
        }*/
    }
}
