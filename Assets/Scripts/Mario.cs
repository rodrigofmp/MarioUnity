using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    private GameBehaviour _game;

    private MarioColliderHelper _bottomHelper;
    private MarioColliderHelper _rightHelper;
    private MarioColliderHelper _leftHelper;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;

    private bool _isJumping = false;
    private bool _isDead = false;

    public float Velocity = 5f;
    public float JumpForce = 200f;

    void Start()
    {
        _game = GameObject.Find("Main Camera").GetComponent<GameBehaviour>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _bottomHelper = GetComponentsInChildren<MarioColliderHelper>()[0];
        _rightHelper = GetComponentsInChildren<MarioColliderHelper>()[1];
        _leftHelper = GetComponentsInChildren<MarioColliderHelper>()[2];
    }

    void Update()
    {
        if (!_game.IsGameRunning)
        {
            _animator.SetFloat("Velocity", 0);
            return;
        }
        else if (_isDead)
        {
            return;
        }

        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A) && !_leftHelper.IsColliding)
        {
            dir.x = -1;
        }
        else if (Input.GetKey(KeyCode.D) && !_rightHelper.IsColliding)
        {
            dir.x = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 0);
            _rb.AddForce(new Vector2(0, JumpForce));
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

        _isJumping = !_bottomHelper.IsColliding;
        _animator.SetBool("Jump", _isJumping);
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

    public void Kill()
    {
        if (!_isDead)
        { 
            _isDead = true;
            _animator.SetBool("Dead", true);
        }
    }
}
