using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WoodChoppingScript : MonoBehaviour

{
    public float nextSceneTime = 5;
    public float nextRoundTime = 2;
    public float resetNextRound = 2;

    public Animation squareAnim;
    //public Animation slashAnim;
    //public Animator slashAnim;

    public Text totalDisplayed;

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

    public GameObject endGameUI;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
       squareAnim = GetComponent<Animation>();
        //slashAnim = GetComponent<Animation>();
        endGameUI.gameObject.SetActive(false);
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown("e"))
            {
                squareAnim.Stop();
                isPlaying = false;

                manager.GetComponent<PostWwiseEvent>().PlayWoodChopSound();

                if (isGreen && isOrange) //test this 
                {
                    OrangeScore();
                }

                else if (isGreen)
                {
                    GreenScore();
                } 

                else if (isOrange && isRed) //test this
                {
                    RedScore();
                }

                else if (isOrange)
                {
                    OrangeScore();
                }

                else if (isRed)
                {
                    RedScore();
                }
            }
        }

        else if (!isPlaying)
        {
            RestartRound();

            //slashAnim.SetBool("Play", false);
        }
    }

    //registers collisions
    void OnTriggerEnter2D(Collider2D other) 
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
        //Debug.Log("red scored"); 
        addWood = 5;
        TotalWood();
        prevWood = totalWood;
    }

    //what happens after stopped. score add + restart round or end minigame
    private void RestartRound()
    {
        nextRoundTime -= Time.deltaTime;

        if (nextRoundTime < 0)
        {
            nextRoundTime = resetNextRound;

            addRound++;
            totalRounds = prevRound + addRound;
            prevRound = totalRounds;

            if (totalRounds <= 3)
            {
                isPlaying = true;
                squareAnim.Play();
            }

            else
            {
                //SceneManager.LoadScene("Campsite");
                GameOver();
            }
        }
    }
        
    void TotalWood()
    {
        totalWood = prevWood + addWood;
        Debug.Log(totalWood);
        DisplayTotal();
    }

    void DisplayTotal()
    {
        totalDisplayed.text = totalWood.ToString() + " Total";
    }

     void GameOver() 
    {
        endGameUI.gameObject.SetActive(true);
    }
}
