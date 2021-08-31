using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{
    public AK.Wwise.Event MyEvent1;
    public AK.Wwise.Event MyEvent2;
    public AK.Wwise.Event MyEvent3;
    public AK.Wwise.Event MyEvent4;

    public void PlayFootstepSound()
    {
        MyEvent1.Post(gameObject);
    }

    public void PlaySelectSound()
    {
        MyEvent2.Post(gameObject);
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