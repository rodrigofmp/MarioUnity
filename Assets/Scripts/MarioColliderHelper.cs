using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MarioColliderHelper : MonoBehaviour
{
    public bool IsColliding = false;

    public Action<Collider2D> OnTriggerEnter2DAction;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Platform"))
        {
            IsColliding = true;
        }

        OnTriggerEnter2DAction?.Invoke(coll);
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Platform"))
        {
            IsColliding = false;
        }
    }
}
