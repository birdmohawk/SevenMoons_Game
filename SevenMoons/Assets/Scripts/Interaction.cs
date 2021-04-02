using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject landmark;

    // Start is called before the first frame update
    void Start()
    {
        landmark.gameObject.SetActive(false);
    }

    void Update() 
    {
      
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Landmark")
        {
            Debug.Log ("landmark in");
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
