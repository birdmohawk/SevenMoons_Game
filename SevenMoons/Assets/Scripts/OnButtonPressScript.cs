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
            OnButtonPress6();
            OnButtonPress7();
            OnButtonPress8();
            OnButtonPress9();
            //future scenes/minigames go here - order in build settings and list below
        }
    }

    public void OnButtonPress() //OpeningNarrative scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        SceneManager.LoadScene("Forest");
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

    public void OnButtonPress10() //Day 1 Night for PGF
    {
        SceneManager.LoadScene("Day 1 Night");
    }

    public void OnButtonPress11() //Day 1 Night for PGF
    {
        SceneManager.LoadScene("Ruined_Town");
    }
}
