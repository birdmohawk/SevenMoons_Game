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
        /*if (Input.GetKeyDown("space"))
        {
            OnButtonPress();
            OnButtonPress2();
            OnButtonPress3();
            OnButtonPress4();
            OnButtonPress5();
            OnButtonPress6();
            OnButtonPress7();
            OnButtonPress8();
            OnButtonPress9();
            OnButtonPress10();
            OnButtonPress11();
            OnButtonPress12();
            OnButtonPress13();
            //future scenes/minigames go here - order in build settings and list below
        }*/
    }

    public void OnButtonPress() //OpeningNarrative scene
    {
        SceneManager.LoadScene("Opening Narrative");
    }

    public void OnButtonPress2() //Campsite scene
    {
        SceneManager.LoadScene("Campsite");
    }

    public void OnButtonPress3() //River scene
    {
        SceneManager.LoadScene("River");
    }

    public void OnButtonPress4() //Forest scene
    {
        SceneManager.LoadScene("TrueForest");
    }

    public void OnButtonPress5() //WoodChopMinigame scene
    {
        SceneManager.LoadScene("WoodChopMinigame");
    }

    public void OnButtonPress6() //FishingMinigame scene
    {
        SceneManager.LoadScene("FishingMinigame");
    }

    public void OnButtonPress7() //ExerciseMinigame scene
    {
        SceneManager.LoadScene("ExerciseMinigame");
    }

    public void OnButtonPress8() //CollectBerriesMinigame scene
    {
        SceneManager.LoadScene("CollectBerriesMinigame");
    }

    public void OnButtonPress9() //ChopReedsMinigame scene
    {
        SceneManager.LoadScene("ChopReedsMinigame");
    }

    public void OnButtonPress10() //Day 2 Intro
    {
        SceneManager.LoadScene("Day 2 Intro");
    }

    public void OnButtonPress11() //Ruined Town
    {
        SceneManager.LoadScene("Ruined_Town");
    }

    public void OnButtonPress12() //quits game
    {
        Application.Quit();
    }

    public void OnButtonPress13() //Day 1 Day for PGF
    {
        SceneManager.LoadScene("Day 1 Intro");
    }

    public void OnButtonPress14() //Day 1 Day for PGF
    {
        SceneManager.LoadScene("StartGame");
    }
    public void OnButtonPress15() //Day 3 Intro
    {
        SceneManager.LoadScene("Day 3 Intro");
    }
    public void OnButtonPress16() //Day 4 Intro
    {
        SceneManager.LoadScene("Day 4 Intro");
    }
    public void OnButtonPress17() //Day 5 Intro
    {
        SceneManager.LoadScene("Day 5 Intro");
    }
    public void OnButtonPress18() //Day 6 Intro
    {
        SceneManager.LoadScene("Day 6 Intro");
    }
    public void OnButtonPress19() //Day 7 Intro
    {
        SceneManager.LoadScene("Day 7 Intro");
    }
}
