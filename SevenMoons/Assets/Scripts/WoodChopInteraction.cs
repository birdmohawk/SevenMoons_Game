using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WoodChopInteraction : MonoBehaviour
{
    public GameObject taskboardButton;

    private bool inRange; //needed to call MoreInfo() function in fixedupdate so that it checks every frame vs OnTriggerStay not working bc stupid 

    // Start is called before the first frame update
    void Start()
    {
        taskboardButton.gameObject.SetActive(true); //doing this bc it seems to stop the jumping??maybe bc preloaded idk?
        taskboardButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (inRange && Input.GetKey(KeyCode.Space))
        {
            Taskboard();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark in");
            TaskboardButton();

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark out");
            NoTaskboardButton();

            inRange = false;
        }
    }

    public void TaskboardButton()
    {
        taskboardButton.gameObject.SetActive(true);
    }

    public void NoTaskboardButton()
    {
        taskboardButton.gameObject.SetActive(false);
    }

    public void Taskboard()
    {
        taskboardButton.gameObject.SetActive(false);
        SceneManager.LoadScene("WoodChopMinigame");
    }
}
