using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTimeOfDayRTPC : MonoBehaviour
{
    public AK.Wwise.RTPC TimeOfDayRTPC;

    // Update is called once per frame
    void Update()
    {
        /*int time = GameManagerScript.gamemanager.tasks;

        if (time == 3)
        {
            TimeOfDayRTPC.SetGlobalValue(3f);
            Debug.Log("value is 3");
        }

        else
        {
            TimeOfDayRTPC.SetGlobalValue(1);
        }*/

        TimeOfDayRTPC.SetGlobalValue(GameManagerScript.gamemanager.tasks); //put in start?
    }

}
