using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    public string NextLevel = null;
    public float LoadDelay = 3f;

    private float _counter = 0;
    private bool _loadNextLevel = false;

    void Update()
    {
        if (_loadNextLevel)
        {
            _counter += Time.deltaTime;
            if (_counter >= LoadDelay)
            {
                _loadNextLevel = false;
                SceneManager.LoadScene(NextLevel);            
            }            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mario"))
        {
            GameBehaviour game = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();
            if (game.IsGameRunning)
            {
                game.IsGameRunning = false;

                if (!string.IsNullOrEmpty(NextLevel))
                {
                    _loadNextLevel = true;
                }
            }
        }
    }
}
