using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueNarrative : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public Image[] characterPortraits;
    public Image characterSpeaker;
    private int index;
    private int imageIndex;
    public float typingSpeed;

    public GameObject continueButton;

    public Image artemisImage;
    public Image griffinImage;
    public Image albertImage;
    public Image hapiImage;
    public Image everyoneImage;

    void Start()
    {
        StartCoroutine(Type());
        artemisImage.enabled = false;
        albertImage.enabled = false;
        griffinImage.enabled = false;
        hapiImage.enabled = false;
        everyoneImage.enabled = false;
        characterSpeaker = characterPortraits[0];
        characterSpeaker.enabled = true;
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        NextImage();

        if(index < sentences.Length - 1)
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

    public void NextImage()
    {
        characterSpeaker.enabled = false;    
        imageIndex++;
            characterSpeaker = characterPortraits[imageIndex];
        characterSpeaker.enabled = true;
            
    }
}
