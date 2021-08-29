using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWwiseEvent : MonoBehaviour
{
    public AK.Wwise.Event MyEvent;
    public void PlayFootstepSound()
    {
        MyEvent.Post(gameObject);
    }

    public void PlaySelectSound()
    {
        MyEvent.Post(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    // Update is called once per frame.
    void Update()
    {

    }
}