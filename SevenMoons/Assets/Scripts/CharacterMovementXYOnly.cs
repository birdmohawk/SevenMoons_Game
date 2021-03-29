using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementXYOnly : MonoBehaviour
{
    public float speed = 10;

    Vector2 lastMove;
    Vector2 moveDirection;

    bool wasMovingV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        bool isMovingH = Mathf.Abs(h) > 0f;

        float v = Input.GetAxis("Vertical");
        bool isMovingV = Mathf.Abs(v) > 0f;

        if (isMovingH && isMovingV) //need to set lastdirection for if 2 keys pressed
        {
            if (wasMovingV)
            {
                moveDirection = new Vector2(h, 0);
                transform.Translate(moveDirection * speed * Time.deltaTime);
                lastMove = new Vector2(h, 0f);
            }

            else
            {
                moveDirection = new Vector2(0, v);
                transform.Translate(moveDirection * speed * Time.deltaTime);
                lastMove = new Vector2(0f, v);
            }
        }

        else if (isMovingH)
        {
            moveDirection = new Vector2(h, 0);
            transform.Translate(moveDirection * speed * Time.deltaTime);
            wasMovingV = false;
            lastMove = new Vector2(h, 0f);
        }

        else if (isMovingV)
        {
            moveDirection = new Vector2(0, v);
            transform.Translate(moveDirection * speed * Time.deltaTime);
            wasMovingV = true;
            lastMove = new Vector2(h, 0f);
        }
    }
}