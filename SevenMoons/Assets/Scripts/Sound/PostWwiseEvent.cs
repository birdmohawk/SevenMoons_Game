using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{
    public AK.Wwise.Event Footsteps;
    public AK.Wwise.Event Select;
    public AK.Wwise.Event MyEvent3;
    public AK.Wwise.Event MyEvent4;

    public void PlayFootstepSound()
    {
        Footsteps.Post(gameObject);
    }

    public void PlaySelectSound()
    {
        Select.Post(gameObject);
    }

    public void PlayWoodChopSound()
    {
        MyEvent3.Post(gameObject);
    }
    
    public void PlayBobberSound()
    {
        MyEvent4.Post(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    // Update is called once per frame.
    void Update()
    {

    }
}