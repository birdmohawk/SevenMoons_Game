using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterSelection : Encounters
{
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            OnOptionPress();
            
        }
        else if (Input.GetKey("space"))
        {
            OnOption2Press();
        }
        
    }

    void OnOptionPress()
    {
        selected = true;
        Debug.Log("UpgradedStat");
    }

    void OnOption2Press()
    {
        selected = true;
        Debug.Log("DowngradedStat");
    }
    
}
