using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    Animator _animator;
    AudioSource _audio;

    public bool IsActive = false;
    public float SoundDelay = 0.25f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Mario") && !IsActive)
        {
            IsActive = true;
            _animator.SetBool("Active", IsActive);
            _audio.PlayDelayed(SoundDelay);
            GameObject.Find("Main Camera").GetComponent<GameBehaviour>().AddCoin();
        }
    }
}
