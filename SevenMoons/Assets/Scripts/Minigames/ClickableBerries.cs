using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickableBerries : MonoBehaviour
{
    public float nextSceneTime = 5;
    int clicks = 0;

    public GameObject berry;

    public GameObject goodUI;
    public GameObject badUI;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseDown()
    {
      
        
    }

    private void GameOver()
    {
        nextSceneTime -= Time.deltaTime;
        Debug.Log("GameOver");
        berry.gameObject.SetActive(false);

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");*
            SceneManager.LoadScene("Campsite");
        }
    }
}
