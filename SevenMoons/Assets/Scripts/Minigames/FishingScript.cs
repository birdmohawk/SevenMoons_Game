using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FishingScript : MonoBehaviour
{
    //public float nextSceneTime = 5;
    public float nextRoundTime = 2;
    public float resetNextRound = 2;

    public Animation squareAnim;

    public Text totalDisplayed;

    private bool isPlaying;
    private bool isFish;

    private int totalFish;
    private int addFish;
    private int prevFish;

    private int totalRounds;
    private int addRound;
    private int prevRound;

    public GameObject fish = null;
    public Transform[] spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        squareAnim = GetComponent<Animation>();
        isPlaying = true;
        GenerateFish();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown("space"))
            {
                squareAnim.Stop();
                //sliderAnim.SetBool("isPlaying", false);
                isPlaying = false;

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

    /*public void SpawnFish()
    {
        int randomPos = UnityEngine.Random.Range(0, spawnPos.Length);
    }*/

    public void DestroyFish()
    {
        if (fish != null)
        {
            Destroy(fish);
        }
        fish = null;
    }

    public void GenerateFish()
    {
        DestroyFish();
        
        Debug.Log("Fish Generated");
        int randomPos = UnityEngine.Random.Range(0, spawnPos.Length);
        Instantiate(fish);
    }

    public void PositionFish(GameObject berry, Vector2 pos)
    {
        berry.transform.position = pos;
        berry.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fish")
        {
            Debug.Log("fish");
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
            Debug.Log("no fish");
            isFish = false;
        }
    }

    void FishScore()
    {
        addFish = 1;
        TotalFish();
        prevFish = totalFish;
    }

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

                //sliderAnim.SetBool("isPlaying", true);
            }

            else
            {
                GameOver();
            }
        }
    }

    void TotalFish()
    {
        totalFish = prevFish + addFish;
        Debug.Log(totalFish);
        DisplayTotal();
    }

    void DisplayTotal()
    {
        totalDisplayed.text = totalFish.ToString() + " Total";
    }

    private void GameOver()
    {
        //nextSceneTime -= Time.deltaTime;
        Debug.Log("GameOver");

        /*if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");*
            SceneManager.LoadScene("Campsite");
        }*/
    }
}