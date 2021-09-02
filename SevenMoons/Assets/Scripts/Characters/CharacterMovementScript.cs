using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public float speed = 10;
    public LayerMask Base;
    
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
        Movement();
    }

    private void Movement()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveH, moveV);
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1); //clamps all directions (diagonals) to same speed
        transform.Translate(moveDirection * speed * Time.deltaTime);

        //AKSoundEngine.PostEvent("Footsteps", gameObject);
    }
}
