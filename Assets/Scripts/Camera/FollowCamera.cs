using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera
{
    Transform _transform;
    public FollowCamera(IEntity iEntity)
    {
        _transform = iEntity.Transform;
    }

    public void PlayerFollow(Transform lookTarget, float speed, Vector3 distance)
    {
        Vector3 hPos = lookTarget.position + distance;
        Vector3 vPos = Vector3.Lerp(_transform.position, hPos, speed * Time.deltaTime);
        _transform.position = vPos;
        _transform.LookAt(lookTarget.position);
    }
}
