using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioColliderHelper : MonoBehaviour
{

    public bool IsColliding = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Platform"))
        {
            IsColliding = true;
        }        
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Platform"))
        {
            IsColliding = false;
        }
    }
}
