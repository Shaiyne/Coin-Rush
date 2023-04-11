using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MobilePosition
{
    private void Awake()
    {
        Speed = 3f;
        MaxY = 2f;
        MinY = -2f;
        MaxMinZ = 0.5f;
        MaxMinX = 2f;
        SetRandomPosition(true, true, false);
    }
    private void Start()
    {
        BeginningPosition = this.transform.localPosition;
    }
    private void Update()
    {
        ChangingPosition(new Vector3(BeginningPosition.x, MinY, BeginningPosition.z),new Vector3(BeginningPosition.x,MaxY, BeginningPosition.z) , BeginningPosition);
    }
}
