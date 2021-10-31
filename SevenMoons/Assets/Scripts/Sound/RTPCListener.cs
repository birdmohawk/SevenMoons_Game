using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTPCListener : MonoBehaviour
{
    public AK.Wwise.RTPC TimeOfDayRTPC;

    public AK.Wwise.RTPC DayNumberRTPC;

    public AK.Wwise.Event DayNumber;

    // Update is called once per frame
    void Start()
    {
        TimeOfDayRTPC.SetGlobalValue(GameManagerScript.gamemanager.tasks); //put in start?
        DayNumberRTPC.SetGlobalValue(GameManagerScript.gamemanager.nights); //put in start?

        if (GameManagerScript.gamemanager.nights == 0)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day1", gameObject);
            DayNumber.Post(gameObject);
        }

        if (GameManagerScript.gamemanager.nights == 1)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day2", gameObject);
            DayNumber.Post(gameObject);
        }

        if (GameManagerScript.gamemanager.nights == 2)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day3", gameObject);
            DayNumber.Post(gameObject);
        }

        if (GameManagerScript.gamemanager.nights == 3)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day4", gameObject);
            DayNumber.Post(gameObject);
        }

        if (GameManagerScript.gamemanager.nights == 4)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day5", gameObject);
            DayNumber.Post(gameObject);
        }

        if (GameManagerScript.gamemanager.nights == 5)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day6", gameObject);
            DayNumber.Post(gameObject);
        }

        if (GameManagerScript.gamemanager.nights >=6)
        {
            AkSoundEngine.SetSwitch("Ambience_DayNumber", "Day7", gameObject);
            DayNumber.Post(gameObject);
        }

    }

    void OnDestroy()
    {
        DayNumber.Stop(gameObject);
    }
}
