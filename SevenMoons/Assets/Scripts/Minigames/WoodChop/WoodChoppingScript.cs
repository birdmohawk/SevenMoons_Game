using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class WoodChoppingScript : MonoBehaviour
{
    public float nextSceneTime = 5;
    public float nextRoundTime = 2;
    public float resetNextRound = 2;

    public Animation squareAnim;
    //public Animation slashAnim;
    //public Animator slashAnim;
    private bool isPlaying;
    private bool ended = false;

    private bool isGreen;
    private bool isOrange;
    private bool isRed;

    private int totalWood;
    private int addWood;
    private int prevWood;

    private int totalRounds;
    private int addRound;
    private int prevRound;

    public GameObject[] bestGameUI;
    public GameObject[] goodGameUI;
    public GameObject[] badGameUI;
    GameObject bestUI;
    GameObject goodUI;
    GameObject badUI;

    public GameObject endGameUI;

    public GameObject manager;
    
    public GameObject instructions;
    public GameObject redScoreUI;
    public GameObject orangeScoreUI;
    public GameObject greenScoreUI;

    /* Using Awake() so that UI is deactivated before Start() so that
     * DialogueMinigames (script) Type() doesn't get called at start of game */
    void Awake()
    {
        //squareAnim = GetComponent<Animation>();
        //slashAnim = GetComponent<Animation>();
        endGameUI.gameObject.SetActive(false);

        foreach (GameObject obj in bestGameUI)
        {
            obj.SetActive(false);
        }
        
        foreach (GameObject obj in goodGameUI)
        {
            obj.SetActive(false);
        } 
        
        foreach (GameObject obj in badGameUI)
        {
            obj.SetActive(false);
        }

        redScoreUI.gameObject.SetActive(false);
        orangeScoreUI.gameObject.SetActive(false);
        greenScoreUI.gameObject.SetActive(false);

        isPlaying = true;
    }

    void Start()
    {
        GameManagerScript.gamemanager.TaskNumber();
    }

    // Update is called once per frame
    void Update()
    {
        InPlay();
    }

    void InPlay()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown("e"))
            {
                squareAnim.Stop();
                isPlaying = false;

                manager.GetComponent<PostWwiseEvent>().PlayWoodChopSound();

                if (isGreen && isOrange)
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
        addWood = 3;
        TotalWood();
        prevWood = totalWood;
        greenScoreUI.gameObject.SetActive(true);

        GameManagerScript.gamemanager.BestScore();
    }

    void OrangeScore()
    {
        //Debug.Log("orange scored"); 
        addWood = 1;
        TotalWood();
        prevWood = totalWood;
        orangeScoreUI.gameObject.SetActive(true);
        GameManagerScript.gamemanager.GoodScore();
    }

    void RedScore()
    {
        //Debug.Log("red scored"); 
        addWood = 0;
        TotalWood();
        prevWood = totalWood;
        redScoreUI.gameObject.SetActive(true);
        GameManagerScript.gamemanager.BadScore();
    }

    //what happens after stopped. score add + restart round or end minigame
    private void RestartRound()
    {
        if (totalRounds <= 2)
        {
            nextRoundTime -= Time.deltaTime;

            if (nextRoundTime < 0)
            {
                nextRoundTime = resetNextRound;

                addRound++;
                totalRounds = prevRound + addRound;
                prevRound = totalRounds;

                isPlaying = true;
                squareAnim.Play();

                redScoreUI.gameObject.SetActive(false);
                orangeScoreUI.gameObject.SetActive(false);
                greenScoreUI.gameObject.SetActive(false);
            }
        }

        else
        {
            GameOver();
        }
    }
        
    void TotalWood()
    {
        totalWood = prevWood + addWood;
        Debug.Log(totalWood);
    }

     void GameOver() 
     {
        instructions.gameObject.SetActive(false);

        redScoreUI.gameObject.SetActive(false);
        orangeScoreUI.gameObject.SetActive(false);
        greenScoreUI.gameObject.SetActive(false);

        endGameUI.gameObject.SetActive(true);

        if (!ended)
        {
            if (totalWood < 2)
            {
                int index = UnityEngine.Random.Range(0, badGameUI.Length);
                badGameUI[index].SetActive(true);
                Debug.Log("Ending is #: " + index);

                ended = true;
            }

            else if (totalWood > 7)
            {
                int Index = UnityEngine.Random.Range(0, bestGameUI.Length);
                bestGameUI[Index].SetActive(true);

                ended = true;
            }

            else
            {
                int Index = UnityEngine.Random.Range(0, goodGameUI.Length);
                goodGameUI[Index].SetActive(true);

                ended = true;
            }
        }
     } 
}
