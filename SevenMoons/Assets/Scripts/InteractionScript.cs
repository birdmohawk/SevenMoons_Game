using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour
{
    public GameObject interactButton;
    public string SceneName;
    public GameObject manager;

    private bool inRange; 

    // Start is called before the first frame update
    void Start()
    {
        //interactButton.gameObject.SetActive(true); //doing this bc it seems to stop the jumping??maybe bc preloaded idk?
        interactButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (inRange && Input.GetKey(KeyCode.E))
        {
            Taskboard();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark in");
            InteractButton();

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark out");
            NoInteractButton();

            inRange = false;
        }
    }

    public void InteractButton()
    {
        interactButton.gameObject.SetActive(true);
    }

    public void NoInteractButton()
    {
        interactButton.gameObject.SetActive(false);
    }

    public void Taskboard()
    {
        interactButton.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneName);
        manager.GetComponent<PostWwiseEvent>().PlaySound0();
        inRange = false;
    }
}
