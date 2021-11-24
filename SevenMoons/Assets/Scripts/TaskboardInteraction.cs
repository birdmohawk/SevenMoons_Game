using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskboardInteraction : MonoBehaviour
{
    public GameObject taskboardButton;
    public GameObject taskboard;

    //public GameObject character;
    public GameObject charCanvas;
    public Camera camera;

    public GameObject manager;

    private bool inRange; 

    // Start is called before the first frame update
    void Start()
    {
        taskboardButton.gameObject.SetActive(false);
        taskboard.gameObject.SetActive(false);
        camera.gameObject.SetActive(false);
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
        //character.gameObject.SetActive(false);
        charCanvas.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        taskboardButton.gameObject.SetActive(false);
        taskboard.gameObject.SetActive(true);
        manager.GetComponent<PostWwiseEvent>().PlaySound0();
        //SceneManager.LoadScene("Taskboard");

        inRange = false;
    }

    public void TaskboardExit()
    {
        //character.gameObject.SetActive(true);
        charCanvas.gameObject.SetActive(true);
        camera.gameObject.SetActive(false);
        //taskboardButton.gameObject.SetActive(false);
        taskboard.gameObject.SetActive(false);
        //SceneManager.LoadScene("Taskboard");
    }
}
