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

    public GameObject[] bestGameUI;
    public GameObject[] goodGameUI;
    public GameObject[] badGameUI;
    public GameObject endGameUI;
    private bool ended = false;

    void Awake()
    {
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
                manager.GetComponent<PostWwiseEvent>().PlaySound3(); //bobber sound, assigned in PostWwiseEvent script on manager

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

    private void GameOver()
    {
        totalFish = prevFish + addFish;
        instructions.gameObject.SetActive(false);

        endGameUI.gameObject.SetActive(true);

        if (!ended)
        {
            ended = true;

            if (totalFish < 1)
            {
                int index = UnityEngine.Random.Range(0, badGameUI.Length);
                badGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.BadScore();
            }

            else if (totalFish > 2)
            {
                int index = UnityEngine.Random.Range(0, bestGameUI.Length);
                bestGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.BestScore();
            }

            else
            {
                int index = UnityEngine.Random.Range(0, goodGameUI.Length);
                goodGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.GoodScore();
            }
        }
    }
}