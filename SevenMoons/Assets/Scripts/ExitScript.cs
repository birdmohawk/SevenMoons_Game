using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown("space"))
        {
            OnButtonPress();
        }
    }

    public void OnButtonPress()
    {
        Application.Quit(); ;
    }
}
