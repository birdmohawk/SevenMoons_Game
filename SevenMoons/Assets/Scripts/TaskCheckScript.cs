using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskCheckScript : MonoBehaviour
{
    void Start()
    {
        GameManagerScript.gamemanager.TotalTasks();
    }

    void OnEnable()
    {
        //GameManagerScript.gamemanager.TotalTasks();
    }

    void Update()
    {
        //GameManagerScript.gamemanager.TotalTasks();
    }

}
