using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodChoppingScript : MonoBehaviour

{
    private bool isPlaying;
    private Animation squareAnim;

    // Start is called before the first frame update
    void Start()
    {
        squareAnim = GetComponent<Animation>();
        isPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (isPlaying)
            {
                squareAnim.Stop();
                isPlaying = false;
            }

            else if (!isPlaying)
            {
                squareAnim.Play();
                isPlaying = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Win")
        {
            Debug.Log("win");
        }
    }
}
