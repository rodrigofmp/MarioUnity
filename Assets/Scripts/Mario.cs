﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private bool _isJumping = false;
    private bool _isDead = false;

    public float Velocity = 2f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }

        Vector2 vel = _rb.velocity;
        vel.x = dir.x * Velocity;
        _rb.velocity = vel;

        _animator.SetFloat("Velocity", GetAbsRunVelocity());

        if (_rb.velocity.x > 0)
        {
            _renderer.flipX = true;
        }
        else if (_rb.velocity.x < 0)
        {
            _renderer.flipX = false;
        }
    }

    public float GetAbsRunVelocity()
    {
        return Mathf.Abs(_rb.velocity.x);
    }

    public bool IsJumping()
    {
        return _isJumping;
    }

    public bool IsDead()
    {
        return _isDead;
    }
}
