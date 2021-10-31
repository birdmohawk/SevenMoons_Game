using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueMinigames : MonoBehaviour
{
    public TMP_Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject nextSceneButton;
    private bool dialogueRunning = false;

    void Start()
    {
        /*sometimes this doesn't work, if so move SetActive(false) 
         * components to Awake() in other minigame script*/
        if (gameObject.activeSelf) 
        {
            StartCoroutine(Type());
            nextSceneButton.SetActive(false);
            continueButton.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        dialogueRunning = true;

        foreach (char letter in sentences[index].ToCharArray())
        {
            
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        dialogueRunning = false;
        Buttons();
    }

    void Buttons()
    {
        if (!dialogueRunning)
        {
            if (index < sentences.Length - 1)
            {
                continueButton.SetActive(true);
                nextSceneButton.SetActive(false);
            }

            else
            {
                nextSceneButton.SetActive(true);
            }
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1 && !dialogueRunning)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
        }
    }
}
