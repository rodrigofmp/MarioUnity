using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaTroopa : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    public int Direction = -1;
    public float Velocity = 1f;
    public bool IsAlive = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (IsAlive)
        {
            _rb.velocity = new Vector2(Velocity * Direction, _rb.velocity.y);
        }

        _animator.SetFloat("Velocity", Mathf.Abs(_rb.velocity.x));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform") && IsAlive)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);

            Direction = -Direction;
            this.transform.localScale = new Vector3(
                this.transform.localScale.x * -1, 
                this.transform.localScale.y, 
                this.transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mario"))
        {
            collision.gameObject.GetComponent<Mario>().Kill();
            this.Velocity = 0f;
        }
    }
}
