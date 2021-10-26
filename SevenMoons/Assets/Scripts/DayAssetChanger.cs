using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAssetChanger : MonoBehaviour
{
    public GameObject[] day1; //days 1 and 2
    public GameObject[] day3; //days 3 and 4
    public GameObject[] day5; //days 5 and 6
    public GameObject[] day7; //days 5 and 6

    // Start is called before the first frame update
    void Update()
    {
        CheckAssets();
    }

     public void CheckAssets()
    {
        int dayNumber = GameManagerScript.gamemanager.nights;

        if (dayNumber <= 0 && dayNumber < 3) //days 1  and 2
        {
            Debug.Log("display day 1 and 2 assets");
            
            foreach(GameObject obj in day1) 
            {
            obj.SetActive(true);
            }

             foreach(GameObject obj in day5) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day3) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day7) 
            {
            obj.SetActive(false);
            }
        }

        if (dayNumber >= 3 && dayNumber < 5) //days 3 and 4
        {
            Debug.Log("display day 3 and 4 assets");

            foreach(GameObject obj in day3) 
            {
            obj.SetActive(true);
            }

             foreach(GameObject obj in day5) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day1) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day7) 
            {
            obj.SetActive(false);
            }
        }
        
        if (dayNumber >= 5 && dayNumber < 7) //days 5 and 6
        {
            Debug.Log("display day 5 and 6 assets");

             foreach(GameObject obj in day5) 
            {
            obj.SetActive(true);
            }

            foreach(GameObject obj in day7) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day3) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day1) 
            {
            obj.SetActive(false);
            }
        }

        if (dayNumber >= 7) //day 7
        {
            Debug.Log("display day 7 assets");

            foreach(GameObject obj in day7) 
            {
            obj.SetActive(true);
            }

            foreach(GameObject obj in day5) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day3) 
            {
            obj.SetActive(false);
            }

            foreach(GameObject obj in day1) 
            {
            obj.SetActive(false);
            }
        }
    }
}
