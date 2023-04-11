using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    private float maxMinZ;
    private float minY = -3;
    private float maxY = 1.5f;
    private float maxMinX = 2;
    private float direction;
    private float speed;

    protected float MaxMinZ { get { return maxMinZ; } set { maxMinZ = value; } }
    protected float MinY { get { return minY; } set { minY = value; } }
    protected float MaxY { get { return maxY; } set { maxY = value; } }
    protected float MaxMinX { get { return maxMinX; } set { maxMinX = value; } }

    protected float Speed { get { return speed; } set { speed = value; } }
    protected float Direction { get { return direction; } set { direction = value; } }

    protected virtual void SetPosition(Vector3 vector3)
    {
        transform.position = vector3;
    }

    protected virtual void SetRandomPosition(bool RandomX, bool RandomY, bool RandomZ)
    {
        float posX, posY, posZ;
        if (RandomX) posX = Random.Range(-MaxMinX, MaxMinX);
        else posX = transform.position.x;
        if (RandomY) posY = Random.Range(MinY, MaxY);
        else posY = transform.position.y;
        if (RandomZ) posZ = Random.Range(-MaxMinZ, MaxMinZ);
        else posZ = transform.position.z;
        SetPosition(new Vector3(posX, posY, posZ));
    }
    protected virtual float GetMaxMinRandomDirection(float value)
    {
        return Random.Range(0, 2) == 0 ? -value : value;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.CompareTag("ObstacleTag"))
        {
            CoreSignals.Instance.onLevelFailed?.Invoke();
        }
    }
}
