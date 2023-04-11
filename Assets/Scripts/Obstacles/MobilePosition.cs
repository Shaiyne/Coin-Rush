using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobilePosition : Obstacle
{
    private Vector3 beginningPosition;
    protected Vector3 BeginningPosition { get { return beginningPosition; } set { beginningPosition = value; } }
    private Vector3 targetPosition;
    protected Vector3 TargetPosition { get { return targetPosition; } set { targetPosition = value; } }

    protected virtual void ChangingPosition(Vector3 down, Vector3 up , Vector3 beginPos)
    {
        if (transform.localPosition == up) TargetPosition = down;
        else if (transform.localPosition == down) TargetPosition = up;
        else if (transform.localPosition == beginPos) TargetPosition = down;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetPosition, Speed * Time.deltaTime);
    }
}
