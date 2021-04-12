using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //public GameObject landmark;
    //public GameObject Campfire;


    // Start is called before the first frame update
    void Start()
    {
        //landmark.gameObject.SetActive(false);
        
    }

    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //public GameObject Campfire;

        if (other.tag == "Player")
        {
            //landmark.gameObject.SetActive(true);
            Debug.Log("landmark in");
            //bring up press key for more info dialogue
            //Campfire.GetComponent<LandmarkInteraction>().MoreInfo
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("landmark out");
            //landmark.gameObject.SetActive(false);
            //bring up press key for more info dialogue
        }
    }

}
