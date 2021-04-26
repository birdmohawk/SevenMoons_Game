using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WoodChoppingScript : MonoBehaviour

{
    private Animation squareAnim;

    private bool isPlaying;

    private bool isGreen;
    private bool isOrange;
    private bool isRed;

    private int totalWood;
    private int addWood;
    private int prevWood;

    private int totalRounds;
    private int addRound;
    private int prevRound;

    // Start is called before the first frame update
    void Start()
    {
        squareAnim = GetComponent<Animation>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isPlaying)
            {
                squareAnim.Stop();
                isPlaying = false;

                if (isGreen)
                {
                    GreenScore();
                }

                if (isOrange)
                {
                    OrangeScore();
                }

                if (isRed)
                {
                    RedScore();
                }
            }

            else if (!isPlaying)
            { 
                RestartRound();
            }
        }
    }

    //registers collisions
    void OnTriggerEnter2D(Collider2D other) //green zone
    {
        if (other.tag == "Green")
        {
            //Debug.Log("green");
            isGreen = true;
        }

        if (other.tag == "Orange")
        {
            //Debug.Log("orange");
            isOrange = true;
        }

        if (other.tag == "Red")
        {
            //Debug.Log("red");
            isRed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Green")
        {
            //Debug.Log("no green");
            isGreen = false;
        }

        if (other.tag == "Orange")
        {
            //Debug.Log("no orange");
            isOrange = false;
        }

        if (other.tag == "Red")
        {
            //Debug.Log("no red");
            isRed = false;
        }
    }

    //what happens when you are in green, orange, or red zone
    void GreenScore()
    {
        //Debug.Log("green scored"); 
        addWood = 25;
        TotalWood();
        prevWood = totalWood;
    }

    void OrangeScore()
    {
        //Debug.Log("orange scored"); 
        addWood = 10;
        TotalWood();
        prevWood = totalWood;
    }

    void RedScore()
    {
        //Debug.Log("red scored"); //do something
        addWood = 5;
        TotalWood();
        prevWood = totalWood;
    }

    //what happens after stopped. score add + restart round or end minigame
    void RestartRound()
    {
        addRound++;
        totalRounds = prevRound + addRound;
        prevRound = totalRounds;

        if (totalRounds <= 3)
        {
            squareAnim.Play();
            isPlaying = true;
        }
        
        else
        {
            SceneManager.LoadScene("Campsite");
        }
    }

    void TotalWood()
    {
        totalWood = prevWood + addWood;
        Debug.Log(totalWood);
    }
}
