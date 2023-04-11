using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Rotater
{
    private void Awake()
    {
        SetPosition(new Vector3(transform.position.x, 2.2f, transform.position.z));
        MaxMinX = 1.5f;
        RotateSpeed = RotateSpeed * GetMaxMinRandomDirection(1); // For rotate - or + direction;
    }

    private void Start()
    {
        SetRandomPosition(true, false, false);
    }

    void Update()
    {
        RandomRotater("z",RotateSpeed);
    }

}
