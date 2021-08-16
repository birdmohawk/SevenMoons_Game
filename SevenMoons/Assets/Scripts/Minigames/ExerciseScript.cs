using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExerciseScript : MonoBehaviour
{
    public float speed = 10;
    public float distance = 1;
    public float timeLeft = 5;

    bool play = true;

    public float nextSceneTime = 3;

    private float score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

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
            if (Input.GetKeyDown("a") || Input.GetKeyDown("left") || (Input.GetKeyDown("d") || Input.GetKeyDown("right")))
            {
                Vector2 move = new Vector2(distance, 0);
                transform.Translate(move * speed * Time.deltaTime);
                score++;
            }
        }
    }

    private void GameOver()
    {
        nextSceneTime -= Time.deltaTime;
        Debug.Log(score); //display score in UI!

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");
            SceneManager.LoadScene("Campsite");
        }
    }
}
