using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ExerciseScript : MonoBehaviour
{
    public float speed = 10;
    public float distance = 1;
    public float timeLeft = 5;
    public float startTimeLeft = 3;

    bool play = true;

    private float score = 0;

    public GameObject endGameUI;
    public GameObject timerBox;
    public GameObject instructions;
    public TMP_Text timer;
    private int secondsUI;
    public TMP_Text displayTotal;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        endGameUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartTime();
    }

    private void StartTime()
    {
        startTimeLeft -= Time.deltaTime;
        
        if (startTimeLeft < 0)
        {
            PlayGame();
        }
    }

    private void PlayGame()
    {
        timeLeft -= Time.deltaTime;
        secondsUI = (int)timeLeft;
        timer.text = secondsUI.ToString();

        if (timeLeft > 0)
        {
            play = true;
        }

        if (timeLeft < 0)
        {
            GameOver();
            play = false;
        }

        if (play)
        {
            if (Input.GetKeyDown("a") || (Input.GetKeyDown("d")))
            {
                manager.GetComponent<PostWwiseEvent>().PlayFootstepSound();
                Vector2 move = new Vector2(distance, 0);
                transform.Translate(move * speed * Time.deltaTime);
                score++;
            }
        }
    }

    void TotalScore()
    {
        Debug.Log(score);
        displayTotal.text = score.ToString() + " steps";
    }

    private void GameOver()
    {
        TotalScore();
        endGameUI.gameObject.SetActive(true);
        timerBox.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
    }
}
