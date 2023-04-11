using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rotater : Obstacle
{
    private float rotateSpeed = 50;
    private float limit;

    protected float RotateSpeed { get { return rotateSpeed; } set { rotateSpeed = value; } }

    protected float Limit { get { return limit; } set { limit = value; } }

    protected virtual void RandomRotater(string xyz, float rotSpeed)
    {
        if(xyz == "x")
        {
            transform.Rotate(rotSpeed * Time.deltaTime, 0, 0);
        }
        else if(xyz == "y")
        {
            transform.Rotate(0, rotSpeed * Time.deltaTime, 0);
        }
        else if(xyz == "z")
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);
        }

    }

    protected virtual void RotateAndGetBack(string xyz,float rotSpeed, float limit)
    {
        if (xyz == "x")
        {
            transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * rotSpeed, limit), transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        else if(xyz == "y")
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.PingPong(Time.time * rotSpeed, limit), transform.localEulerAngles.z);
        }
        else if(xyz == "z")
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Mathf.PingPong(Time.time * rotSpeed, limit));
        }
    }

    protected virtual void RotateBetweenOppositeSide(string xyz, float limit, float rotSpeed, float random, float direction)
    {
        float angle = limit * Mathf.Sin(Time.time + random * rotSpeed);

        if(xyz == "x")
        {
            transform.localRotation = Quaternion.Euler(angle * direction, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if(xyz == "y")
        {
            transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, angle * direction, transform.eulerAngles.z);
        }
        else if (xyz == "z")
        {
            transform.localRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, angle * direction);
        }

    }
}
