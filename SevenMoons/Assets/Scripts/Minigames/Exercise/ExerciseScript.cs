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
    public GameObject endGameUI;

    public GameObject[] bestGameUI;
    public GameObject[] goodGameUI;
    public GameObject[] badGameUI;

    private bool ended = false;

    /* Using Awake() so that UI is deactivated before Start() so that
     * DialogueMinigames (script) Type() doesn't get called at start of game */
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
                Vector2 move = new Vector2(distance, 0);
                transform.Translate(move * speed * Time.deltaTime);
                score++;
                manager.GetComponent<PostWwiseEvent>().PlaySound3();
            }
        }
    }

    private void GameOver()
    {
        timerBox.gameObject.SetActive(false);
        instructions.gameObject.SetActive(false);
        endGameUI.gameObject.SetActive(true);

        if (!ended)
        {
            ended = true;

            if (score > 110)
            {
                int index = UnityEngine.Random.Range(0, bestGameUI.Length);
                bestGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.BestScore();
            }

            else if (score > 80)
            {
                int index = UnityEngine.Random.Range(0, goodGameUI.Length);
                goodGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.GoodScore();
            }

            else
            {
                int index = UnityEngine.Random.Range(0, badGameUI.Length);
                badGameUI[index].SetActive(true);
                GameManagerScript.gamemanager.BadScore();
            }
        }
    }
}
