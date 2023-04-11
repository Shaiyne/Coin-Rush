using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    float xRot;
    Transform _transform;
    public PlayerMovement(IEntity entity)
    {
        _transform = entity.Transform;
    }
    protected internal void PlayerMove(float speed)
    {
        if (Input.touchCount > 0)
        {
            float rotX = Input.GetTouch(0).deltaPosition.x * Time.deltaTime * 50 * -1;
            xRot -= rotX;
            xRot = Mathf.Clamp(xRot, -85f, 85);
            _transform.rotation = Quaternion.Euler(0, xRot, 0);
        }
        _transform.position += _transform.forward.normalized * Time.deltaTime * speed;
        //AudioSignals.Instance.onCoinMovementSound?.Invoke();
    }

    protected internal void PlayerMoveStop()
    {
        _transform.position = _transform.position;
    }
    protected internal void PlayerFinishStage(Vector3 stairPos,float value)
    {
        _transform.position = Vector3.Lerp(_transform.position, stairPos,value*Time.deltaTime);

    }
    protected internal void PlayerFinishStageEnd(Vector3 stairPos,float value)
    {
        _transform.position = Vector3.MoveTowards(_transform.position,stairPos,value * Time.deltaTime);
        if (Vector3.Distance(_transform.position, stairPos) < 0.2f)
        {
            CoreSignals.Instance.onLevelSucceded?.Invoke();
        }
    }
}
