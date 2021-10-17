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
    public bool movingOn;

    //private IEnumerator coroutine;

    public GameObject continueButton;

    void Start()
    {
        movingOn = false;

        if (gameObject.activeSelf)
        {
            StartCoroutine(Type());
        }
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }

        if (movingOn == true)
        {
            movingOn = false;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        movingOn = true;

        if (index < sentences.Length - 1)
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
