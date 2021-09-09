using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortingOrderScript : MonoBehaviour
{
    public const string Trees_InFront = "Trees_InFront";
    public const string Trees_Behind = "Trees_Behind";
    public int sortingOrder = 0;
    private TilemapRenderer treesLayer;
    private bool treesBehind;

    // Start is called before the first frame update
    void Start()
    {
        //frontTrees = true;
        treesLayer = GetComponent<TilemapRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (treesBehind)
        {
            //treesLayer.sortOrder = sortingOrder;
            treesLayer.sortingLayerName = Trees_Behind;
        }

        else
        {
            treesLayer.sortingLayerName = Trees_InFront;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        treesBehind = true;
        Debug.Log("player in front of trees");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        treesBehind = false;
        Debug.Log("player behind trees");
    }
}
