using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingOrderScript : MonoBehaviour
{
    public string inFront = "Trees_InFront";
    public string behind = "Trees_Behind";
    public int sortingOrder = 0;
    private TilemapRenderer tm;
    private bool objectBehind;

    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectBehind)
        {
            tm.sortingLayerName = behind;
        }

        else
        {
            tm.sortingLayerName = inFront;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        objectBehind = true;
        Debug.Log("player in front of trees");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        objectBehind = false;
        Debug.Log("player behind trees");
    }
}
