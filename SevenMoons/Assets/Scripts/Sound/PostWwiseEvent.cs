using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{
    /*public AK.Wwise.Event Footsteps;
    public AK.Wwise.Event Select;
    public AK.Wwise.Event WoodChop;
    public AK.Wwise.Event MyEvent4;*/ 

    public AK.Wwise.Event []Sounds; //changed to array so can change number of sounds in each scene as needed and use same script

    public void PlaySound0() //usually use this for select
    {
        Sounds[0].Post(gameObject);
    }

    public void PlaySound1() 
    {
        Sounds[1].Post(gameObject);
    }

    public void PlaySound2() //usually typing sound
    {
        Sounds[2].Post(gameObject);
    }

    public void StopSound2()
    {
        Sounds[2].Stop(gameObject);
    }

    public void PlaySound3()
    {
        Sounds[3].Post(gameObject);
    }

    public void StopSound3()
    {
        Sounds[3].Stop(gameObject);
    }

    public void PlaySound4()
    {
        Sounds[4].Post(gameObject);
    }

    public void PlaySound5()
    {
        Sounds[5].Post(gameObject);
    }

    //add more functions as needed
}