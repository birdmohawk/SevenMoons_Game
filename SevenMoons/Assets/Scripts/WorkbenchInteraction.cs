using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchInteraction : MonoBehaviour
{
    public GameObject pressButton;
    public GameObject dialogue;

    private bool trig; //needed to call MoreInfo() function in fixedupdate so that it checks every frame

    // Start is called before the first frame update
    void Start()
    {
        pressButton.gameObject.SetActive(false);
        dialogue.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (trig && Input.GetKey(KeyCode.Space))
        {
            ButtonPress();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark in");
            MoreInfo();

            trig = true;
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
    }
}
