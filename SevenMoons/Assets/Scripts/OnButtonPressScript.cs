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
        }
    }

    public void OnButtonPress()
    {
        
            SceneManager.LoadScene("Forest");
        
    }
        
}
