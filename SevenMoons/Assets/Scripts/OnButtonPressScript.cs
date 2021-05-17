using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnButtonPressScript : MonoBehaviour
{
    //public Scene target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            OnButtonPress();
            OnButtonPress2();
            OnButtonPress3();
            OnButtonPress4();
            OnButtonPress5();
            //OnButtonPress6(); //future scenes/minigames go here - order in build settings and list below
        }
    }

    public void OnButtonPress() //OpeningNarrative scene
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void OnButtonPress2() //Campsite scene
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    public void OnButtonPress3() //Taskboard scene
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }

    public void OnButtonPress4() //Forest scene
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }

    public void OnButtonPress5() //WoodChopMinigame scene
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }
}
