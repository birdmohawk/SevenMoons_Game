using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmarkInteraction : MonoBehaviour
{
    public GameObject itemName;
    public GameObject itemInfo;

    private bool inRange; //needed to call MoreInfo() function in fixedupdate so that it checks every frame

    // Start is called before the first frame update
    void Start()
    {
        itemInfo.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (inRange && Input.GetKey(KeyCode.Space))
        {
            ItemInfo();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ItemName();

            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            NoItemName();
            NoItemInfo();

            inRange = false;
        }
    }

    public void ItemName()
    {
        itemName.gameObject.SetActive(true);
    }

    public void NoItemName()
    {
        itemName.gameObject.SetActive(false);
    }

    public void ItemInfo()
    {
        //bring up more info for - UI or yarnspinner??both?? what happens on buttonpress goes here and gets called above
        itemInfo.gameObject.SetActive(true);
        itemName.gameObject.SetActive(false);
    }

    public void NoItemInfo()
    {
        itemInfo.gameObject.SetActive(false);
    }
}
