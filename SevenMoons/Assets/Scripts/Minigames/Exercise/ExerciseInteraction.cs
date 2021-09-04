using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExerciseInteraction : MonoBehaviour
{
    public GameObject scavengeButton;

    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        scavengeButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (inRange && Input.GetKey(KeyCode.E))
        {
            Minigame();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player in");
            ScavengeButton();

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player out");
            NoScavengeButton();

            inRange = false;
        }
    }

    public void ScavengeButton()
    {
        scavengeButton.gameObject.SetActive(true);
    }

    public void NoScavengeButton()
    {
        scavengeButton.gameObject.SetActive(false);
    }

    public void Minigame()
    {
        scavengeButton.gameObject.SetActive(false);
        SceneManager.LoadScene("ExerciseMinigame");
    }
}
