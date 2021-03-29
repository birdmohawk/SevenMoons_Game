using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() //or update??
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.up); //change .up??

        if (hit.collider != null && hit.distance <= 1.0f)
        {
            //If the object hit is less than or equal to ? units away from this object.
            
                Debug.Log("Campfire");
            
        }
    }
}
