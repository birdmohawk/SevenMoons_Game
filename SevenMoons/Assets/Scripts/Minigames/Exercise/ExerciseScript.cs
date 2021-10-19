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
    private float goTimeLeft = 1;

    bool play = true;

    private float score = 0;

    public GameObject timerBox;
    public GameObject startTimerBox;
    public GameObject instructions;
    public TMP_Text timer;
    public TMP_Text startTimer;
    private int secondsUI;
    private int secondsUIStart;
    public TMP_Text displayTotal;
    public TMP_Text go;
    public GameObject manager;

    public GameObject bestGameUI;
    public GameObject goodGameUI;
    public GameObject badGameUI;
    public GameObject endGameUI;

    /* Using Awake() so that UI is deactivated before Start() so that
     * DialogueMinigames (script) Type() doesn't get called at start of game */
    void Awake()
    {
        endGameUI.gameObject.SetActive(false);
        bestGameUI.gameObject.SetActive(false);
        goodGameUI.gameObject.SetActive(false);
        badGameUI.gameObject.SetActive(false);
    }

    void Start()
    {
        GameManagerScript.gamemanager.TaskNumber();
    }

    void Update()
    {
        StartTime();
    }

    private void StartTime()
    {
        startTimeLeft -= Time.deltaTime;
        secondsUIStart = (int)startTimeLeft;
        startTimer.text = secondsUIStart.ToString();

        if (startTimeLeft <= 0)
        {
            GoTime();
        }
    }

    private void GoTime()
    {
        goTimeLeft -= Time.deltaTime;
        startTimerBox.gameObject.SetActive(false);
        go.text = "Go!";
        if (goTimeLeft <= 0)
        {
            PlayGame();
        }
    }

    private void PlayGame()
    {
        timeLeft -= Time.deltaTime;
        secondsUI = (int)timeLeft;
        timer.text = secondsUI.ToString();
        go.text = "";

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

    private void GameOver()
    {
        EndGameUI();
        timerBox.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
    }

    void EndGameUI()
    {
        if (score > 100)
        {
            bestGameUI.gameObject.SetActive(true);
            endGameUI.gameObject.SetActive(true);
        }

        else if (score > 80)
        {
            goodGameUI.gameObject.SetActive(true);
            endGameUI.gameObject.SetActive(true);
        }

        else 
        {
            badGameUI.gameObject.SetActive(true);
            endGameUI.gameObject.SetActive(true);
        } 
    }
}
