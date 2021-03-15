using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    Vector3 characterScale;
    float characterScaleX;

    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal"); //left + right arrows

        float moveV = Input.GetAxis("Vertical"); //up + down arrows

        Vector2 movement = new Vector2(moveH, moveV) * speed * Time.deltaTime; //deltaTime moving 
        transform.Translate(movement);

        if (moveH < 0) //determines direction of movement + which way sprite should face left or right
        {
            characterScale.x = -characterScaleX;
        }
        if (moveH > 0)
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;
    }
}
