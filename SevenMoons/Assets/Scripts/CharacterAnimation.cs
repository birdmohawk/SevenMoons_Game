using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator charanim;
    // Start is called before the first frame update
    void Start()
    {
        charanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //left animation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) //maybe use GetButton instead? bc shorter
        {
            charanim.SetBool("isLeft", true);
        }

        else
        {
            charanim.SetBool("isLeft", false);
        }

        //right animation
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            charanim.SetBool("isRight", true);
        }

        else
        {
            charanim.SetBool("isRight", false);
        }

        //up animation
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            charanim.SetBool("isUp", true);
        }

        else
        {
            charanim.SetBool("isUp", false);
        }

        //down animation
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            charanim.SetBool("isDown", true);
        }

        else
        {
            charanim.SetBool("isDown", false);
        }
    }
}
