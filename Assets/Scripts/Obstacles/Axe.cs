using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Rotater
{
    private void Update()
    {
        RotateAndGetBack("x",60, 75);
    }
}
