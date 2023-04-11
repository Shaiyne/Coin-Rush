using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : Rotater
{
    private void Awake()
    {
        SetRandomPosition(true, false, false);
        RotateSpeed *= GetMaxMinRandomDirection(1);
    }

    void Update()
    {
        RandomRotater("z", RotateSpeed);
    }
}
