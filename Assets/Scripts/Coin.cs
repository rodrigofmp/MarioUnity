using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Coin : MonoBehaviour
{
    SpriteRenderer _renderer;
    AudioSource _coinAudio;

    bool _readyToRemove = false;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _coinAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_readyToRemove && !_coinAudio.isPlaying)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Mario") && !_readyToRemove)
        {
            _coinAudio.Play();
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddCoin();
            _readyToRemove = true;
            _renderer.enabled = false;
        }
    }
}
