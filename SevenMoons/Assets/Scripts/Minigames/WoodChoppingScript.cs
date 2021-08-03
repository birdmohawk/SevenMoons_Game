using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WoodChoppingScript : MonoBehaviour

{
    public float nextSceneTime = 5;

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

    // Start is called before the first frame update
    void Start()
    {
       squareAnim = GetComponent<Animation>();
       //slashAnim = GetComponent<Animation>();

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

                //slashAnim.Play();

                //slashAnim.SetBool("Play", true);

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

            else if (!isPlaying)
            { 
                RestartRound();

                //slashAnim.SetBool("Play", false);
            }
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
            //SceneManager.LoadScene("Campsite");
            GameOver();
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

     private void GameOver() //need to fix space bar issue
    {
        nextSceneTime -= Time.deltaTime;
        Debug.Log("GameOver");

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");*
            SceneManager.LoadScene("Campsite");
        }
    }

}
