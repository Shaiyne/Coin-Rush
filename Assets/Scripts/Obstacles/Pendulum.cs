using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Rotater
{
    void Awake()
    {
        RotateSpeed = 1.5f;
        Limit = 75;
        SetPosition(new Vector3(transform.position.x, 2.95f, transform.position.z));
        Direction = GetMaxMinRandomDirection(1);
    }

    void Update()
    {
        RotateBetweenOppositeSide("z",Limit, RotateSpeed, 0.2f, Direction);
    }
}
