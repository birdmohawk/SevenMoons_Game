using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementXYOnly : MonoBehaviour
{
    public float speed = 10;

    Vector2 lastMove;
    Vector2 moveDirection;

    bool wasMovingV;
    bool movement;

    private Animator charanim;

    // Start is called before the first frame update
    void Start()
    {
        movement = false;
        charanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        bool isMovingH = Mathf.Abs(h) > 0f;

        float v = Input.GetAxis("Vertical");
        bool isMovingV = Mathf.Abs(v) > 0f;

        charanim.SetFloat("Horizontal", h);
        charanim.SetFloat("Vertical", v);
        charanim.SetFloat("Speed", h + v);
        

        if (isMovingH && isMovingV) 
        {
            if (wasMovingV)
            {
                moveDirection = new Vector2(h, 0);
                lastMove = new Vector2(h, 0f);

                if (h > 0)
                {
                    charanim.SetBool("isRight", true);
                    charanim.SetBool("isLeft", false);
                    charanim.SetBool("isUp", false);
                    charanim.SetBool("isDown", false);
                }

                else
                {
                    charanim.SetBool("isLeft", true);
                    charanim.SetBool("isRight", false);
                    charanim.SetBool("isUp", false);
                    charanim.SetBool("isDown", false);
                }
            }

            else
            {
                moveDirection = new Vector2(0, v);
                lastMove = new Vector2(0f, v);

                if (v > 0)
                {
                    charanim.SetBool("isUp", true);
                    charanim.SetBool("isDown", false);
                    charanim.SetBool("isLeft", false);
                    charanim.SetBool("isRight", false);
                }

                else
                {
                    charanim.SetBool("isDown", true);
                    charanim.SetBool("isUp", false);
                    charanim.SetBool("isLeft", false);
                    charanim.SetBool("isRight", false);
                }
            }
            movement = true;
        }

        else if (isMovingH)
        {
            moveDirection = new Vector2(h, 0);
            wasMovingV = false;
            lastMove = new Vector2(h, 0f);
            movement = true;

            if (h > 0)
            {
                charanim.SetBool("isRight", true);
                charanim.SetBool("isLeft", false);
            }

            else
            {
                charanim.SetBool("isLeft", true);
                charanim.SetBool("isRight", false);
            }
        }

        else if (isMovingV)
        {
            moveDirection = new Vector2(0, v);
            wasMovingV = true;
            lastMove = new Vector2(h, 0f);
            movement = true;

            if (v > 0)
            {
                charanim.SetBool("isUp", true);
                charanim.SetBool("isDown", false);
            }

            else
            {
                charanim.SetBool("isDown", true);
                charanim.SetBool("isUp", false);
            }
        }

        else 
        {
            movement = false;
            charanim.SetBool("isLeft", false);
            charanim.SetBool("isRight", false);
            charanim.SetBool("isUp", false);
            charanim.SetBool("isDown", false);
        }

    }

    void FixedUpdate()
    {
        if (movement) //only moves when movement = true, stops sliding
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }
    }
}
