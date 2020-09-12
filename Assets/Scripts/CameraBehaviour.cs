using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Transform Target;

    public Vector2 Offset = new Vector2(0f, -3f);
    public Vector2 LearpAmount = new Vector2(0.3f, 0.1f);

    void Start()
    {
        Target = GameObject.Find("Mario").transform;

        if (Target != null)
        {
            Vector3 pos = this.transform.position;
            pos.x = Target.position.x + Offset.x;
            pos.y = Target.position.y + Offset.y;
            this.transform.position = pos;
        }
    }

    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x = Mathf.Lerp(pos.x, Target.position.x + Offset.x, LearpAmount.x);
        pos.y = Mathf.Lerp(pos.y, Target.position.y + Offset.y, LearpAmount.y);

        this.transform.position = pos;
    }
}
