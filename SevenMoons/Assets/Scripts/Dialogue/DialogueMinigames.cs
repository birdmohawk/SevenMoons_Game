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

    void Start()
    {
        /*sometimes this doesn't work, if so move SetActive(false) 
         * components to Awake() in other script*/
        if (gameObject.activeSelf) 
        {
            StartCoroutine(Type());
            //nextSceneButton.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        if (index < sentences.Length - 1)
        {
            continueButton.SetActive(true);
            //nextSceneButton.SetActive(false);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            textDisplay.text = "";
            nextSceneButton.SetActive(true);
        }
    }
}
