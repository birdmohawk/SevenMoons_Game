using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingOrderScript : MonoBehaviour
{
    public string inFront = "Trees_InFront";
    public string behind = "Trees_Behind";
    //public int sortingOrder = 0;
    private TilemapRenderer tm;
    private SpriteRenderer character;
    private bool objectBehind;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TilemapRenderer>();
        //character = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectBehind)
        {
            tm.sortingLayerName = behind;
            //character.sortingOrder = 1;
        }

        else
        {
            tm.sortingLayerName = inFront;
            //character.sortingOrder = 0;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        objectBehind = true;
        Debug.Log("player in front");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        objectBehind = false;
        Debug.Log("player behind");
    }
}
