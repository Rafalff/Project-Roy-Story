using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public float speed = 2;
    int dir = 1;

    public Transform RightSide;
    public Transform LeftSide;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * dir * Time.fixedDeltaTime);
        if (Physics2D.Raycast(RightSide.position, Vector2.down, 2) == false)
            dir = -1;

        if (Physics2D.Raycast(LeftSide.position, Vector2.down, 2) == false)
            dir = 1;
    }
}
