using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour , IEntity
{
    FollowCamera _followCamera;
    Transform _player;
    [SerializeField] Vector3 distance;
    float speed = 10f;

    public Transform Transform => transform;

    private void Awake()
    {
        _followCamera = new FollowCamera(this);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        _followCamera.PlayerFollow(_player, speed, distance);
    }
}
