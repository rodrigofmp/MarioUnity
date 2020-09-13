using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public int Coins = 0;
    public bool IsGameRunning = true;
    
    private float _restartClock = 0f;

    private Mario _marioScript;

    void Start()
    {
        GameObject startPoint = GameObject.Find("StartPoint");
        if (startPoint == null)
            throw new UnityException("Start point not found on the scene!");

        GameObject mario = GameObject.Find("Mario");
        if (mario == null)
            throw new UnityException("Mario not found on the scene!");

        _marioScript = mario.GetComponent<Mario>();

        mario.transform.position = new Vector3(startPoint.transform.position.x, 
            startPoint.transform.position.y-1, 0);

        GameObject exitPoint = GameObject.Find("ExitPoint");
        if (exitPoint == null)
            throw new UnityException("Exit point not found on the scene!");
    }

    private void Update()
    {
        if (_marioScript.IsDead())
        {
            _restartClock += Time.deltaTime;
            if (_restartClock >= 3.0f)
            {
                _restartClock = 0f;
                Restart();
            }
        }
    }

    public void AddCoin()
    {
        Coins++;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
