using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollectBerriesScript : MonoBehaviour
{
    public float nextSceneTime = 5;

    public Transform[] spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        SpawnBerryPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnBerryPosition()
    {
        int randomPos1 = UnityEngine.Random.Range(0, spawnPos.Length);

        Transform pos1 = spawnPos[randomPos1];

        Instantiate(GameManagerScript.goodBerry, pos1);
    }

    private void GameOver()
    {
        nextSceneTime -= Time.deltaTime;
        Debug.Log("GameOver");

        if (nextSceneTime < 0) //could use a button to load next scene instead
        {
            //Debug.Log("Load Next Scene");*
            SceneManager.LoadScene("Campsite");
        }
    }

}
