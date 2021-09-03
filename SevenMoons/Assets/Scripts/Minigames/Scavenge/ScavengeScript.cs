using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ScavengeScript : MonoBehaviour
{
    public GameObject endGameUI;
    //private GameObject cloneFish;
    //public GameObject instructions;
    //public TMP_Text displayTotal;

    private bool item;

    void Start()
    {
        endGameUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log("Target name: " + hit.collider.name);

                /*if (hit.collider.CompareTag("NoItem"))
                {
                    Debug.Log("No Item");
                    item = false;
                }*/

                if (hit.collider.CompareTag("NoItem") && hit.collider.CompareTag("Item"))
                {
                    Debug.Log("Both Item");
                    item = false;
                    GameOver();
                }

                /*else if (hit.collider.CompareTag("Item"))
                {
                    Debug.Log("Hit Item");
                    item = true;
                    GameOver();
                    //OnMouseDown();
                }*/
            }

            if (hit.collider != null)
            {
                item = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (item)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        endGameUI.gameObject.SetActive(true);
    }
}