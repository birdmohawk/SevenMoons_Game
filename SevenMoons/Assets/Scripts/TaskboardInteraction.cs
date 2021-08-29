using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskboardInteraction : MonoBehaviour
{
    public GameObject taskboardButton;
    public GameObject taskboard;

    private bool inRange; 

    // Start is called before the first frame update
    void Start()
    {
        //taskboardButton.gameObject.SetActive(true); //doing this bc it seems to stop the jumping??maybe bc preloaded idk?
        taskboardButton.gameObject.SetActive(false);

        taskboard.gameObject.SetActive(false);
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
            TaskboardButton();

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
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
        taskboard.gameObject.SetActive(true);
        //SceneManager.LoadScene("Taskboard");
    }
}
