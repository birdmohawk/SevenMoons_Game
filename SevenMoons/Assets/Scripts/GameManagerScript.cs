using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject landmark;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        landmark.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    //landmark

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Landmark")
        {
            Debug.Log("landmark in");
            landmark.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Landmark")
        {
            Debug.Log("landmark out");
            landmark.gameObject.SetActive(false);
        }
    }
}
