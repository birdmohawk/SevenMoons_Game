using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    private bool inRange;
    public GameObject dialogueButton;
    public GameObject dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogueButton.gameObject.SetActive(false);
        dialogue.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (inRange && Input.GetKey(KeyCode.Space))
        {
            Dialogue();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogueButton();

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            NoDialogueButton();
            NoDialogue();

            inRange = false;
        }
    }

    public void DialogueButton()
    {
        dialogueButton.gameObject.SetActive(true);
    }

    public void NoDialogueButton()
    {
        dialogueButton.gameObject.SetActive(false);
    }

    public void Dialogue()
    {
        dialogue.gameObject.SetActive(true);
        dialogueButton.gameObject.SetActive(false);
    }

    public void NoDialogue()
    {
        dialogue.gameObject.SetActive(false);
    }
}
