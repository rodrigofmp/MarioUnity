using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public int Coins = 0;
    public bool IsGameRunning = true;

    void Start()
    {
        GameObject startPoint = GameObject.Find("StartPoint");
        if (startPoint == null)
            throw new UnityException("Start point not found on the scene!");

        GameObject mario = GameObject.Find("Mario");
        if (mario == null)
            throw new UnityException("Mario not found on the scene!");

        mario.transform.position = new Vector3(startPoint.transform.position.x, 
            startPoint.transform.position.y-1, 0);

        GameObject exitPoint = GameObject.Find("ExitPoint");
        if (exitPoint == null)
            throw new UnityException("Exit point not found on the scene!");
    }

    public void AddCoin()
    {
        Coins++;
    }
}
