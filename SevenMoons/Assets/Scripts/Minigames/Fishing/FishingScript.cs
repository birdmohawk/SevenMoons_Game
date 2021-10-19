using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class FishingScript : MonoBehaviour
{
    //public float nextSceneTime = 5;
    public float nextRoundTime = 2;
    public float resetNextRound = 2;

    public Animation squareAnim;

    //public Text totalDisplayed;

    private bool isPlaying;
    private bool isFish;

    private int totalFish;
    private int addFish;
    private int prevFish;

    private int totalRounds;
    private int addRound;
    private int prevRound;

    public GameObject fish;
    public Transform[] spawnPos;

    public GameObject manager;
    
    private GameObject cloneFish;
    public GameObject instructions;
    //public TMP_Text displayTotal;

    public GameObject bestGameUI;
    public GameObject goodGameUI;
    public GameObject badGameUI;
    public GameObject endGameUI;

    void Awake()
    {
        endGameUI.gameObject.SetActive(false);
        bestGameUI.gameObject.SetActive(false);
        goodGameUI.gameObject.SetActive(false);
        badGameUI.gameObject.SetActive(false);
    }
    void Start()
    {
        squareAnim = GetComponent<Animation>();
        isPlaying = true;
        SpawnFish();

        GameManagerScript.gamemanager.TaskNumber();
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
                manager.GetComponent<PostWwiseEvent>().PlayBobberSound();

                if (isFish) 
                {
                    FishScore();
                }

                else 
                {
                    RestartRound();
                }
            }
        }

        else if (!isPlaying)
        {
            RestartRound();
        }
    }

    private void SpawnFish()
    {
        DestroyFish();

        cloneFish = Instantiate(fish);
        int randomPosIndex = UnityEngine.Random.Range(0, spawnPos.Length);
        PositionFish(cloneFish, spawnPos[randomPosIndex].position);
    }

    public void PositionFish(GameObject fish1, Vector2 pos)
    {
        fish1.transform.position = pos;
    }

    public void DestroyFish()
    {
        if (cloneFish != null)
        {
            Destroy(cloneFish);
        }

        cloneFish = null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            //Debug.Log("fish");
            isFish = true;
        }

        else
        {
            isFish = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            //Debug.Log("no fish");
            isFish = false;
        }
    }

    void FishScore()
    {
        addFish++;
        prevFish = totalFish;
    }

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
                SpawnFish();
            }
        }

        else
        {
            GameOver();
        }
    }

    void TotalFish()
    {
        totalFish = prevFish + addFish;
        //Debug.Log(totalFish);
        //DisplayTotal();
    }

    /*void DisplayTotal()
    {
        displayTotal.text = totalFish.ToString() + " Fish Caught";
    }*/

    private void GameOver()
    {
        //TotalFish();
        totalFish = prevFish + addFish;
        instructions.gameObject.SetActive(false);
        EndGameUI();
    }

    void EndGameUI()
    {
        if (totalFish < 1)
        {
            badGameUI.gameObject.SetActive(true);
            endGameUI.gameObject.SetActive(true);
        }

        else if (totalFish > 2)
        {
            bestGameUI.gameObject.SetActive(true);
            endGameUI.gameObject.SetActive(true);
        }

        else 
        {
            goodGameUI.gameObject.SetActive(true);
            endGameUI.gameObject.SetActive(true);
        } 
    }
}