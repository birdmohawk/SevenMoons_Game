using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    public float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal"); //left + right arrows
        float moveV = Input.GetAxis("Vertical"); //up + down arrows

        Vector2 moveDirection = new Vector2(moveH, moveV); 
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1); //clamps all directions (diagonals) to same speed
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
