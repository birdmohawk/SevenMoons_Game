using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkInteraction : MonoBehaviour
{
    public GameObject pressButton;
    public GameObject dialogue;

    // Start is called before the first frame update
    void Start()
    {
        pressButton.gameObject.SetActive(false);
        dialogue.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark in");
            MoreInfo();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            ButtonPress();
            NoInfo();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark out");
            NoInfo();
            NoButtonPress();
        }
    }

    public void MoreInfo()
    {
        pressButton.gameObject.SetActive(true);
    }

    public void NoInfo()
    {
        pressButton.gameObject.SetActive(false);
    }

    public void ButtonPress()
    {
        //bring up more info for - UI or yarnspinner??both?? what happens on buttonpress goes here and gets called above
        dialogue.gameObject.SetActive(true);
        pressButton.gameObject.SetActive(false);
    }

    public void NoButtonPress()
    {
        dialogue.gameObject.SetActive(false);
        //pressButton.gameObject.SetActive(false);
    }
}
