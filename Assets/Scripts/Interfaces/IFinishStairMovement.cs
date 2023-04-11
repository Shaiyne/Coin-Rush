using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFinishStairMovement
{
    public bool FinishStair { get; set; }
    public bool FinishStage { get; set; }
    public Vector3 StairPos { get; set; }
    public Vector3 MoveToStairPos { get; set; }
    void ClimbStair();
    void MoveToStair();
}
