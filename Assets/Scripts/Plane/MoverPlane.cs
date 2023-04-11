using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlane : MobilePosition
{
    private void Awake()
    {
        MaxMinX = 10;
        Speed = 3;
    }
    private void Start()
    {
        SetRandomPosition(true, false, false);
        BeginningPosition = this.transform.localPosition;
    }
    private void Update()
    {
        ChangingPosition(new Vector3(10, BeginningPosition.y, BeginningPosition.z), BeginningPosition,BeginningPosition);
    }
}
