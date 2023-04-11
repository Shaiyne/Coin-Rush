using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour , IEntity , IFinishStairMovement
{
    PlayerMovement _playerMovement;

    public Transform Transform => transform;

    public bool FinishStair { get ; set ; }
    public bool FinishStage { get; set; }
    public Vector3 StairPos { get; set; }
    public Vector3 MoveToStairPos { get; set; }

    private float _moveSpeed = 3;
    private bool _playerStopMovement;
    private bool _levelStart;

    [SerializeField] TrailRenderer _trailRenderer;
    AudioSource _coinMovementSound;
    private void Awake()
    {
        _playerMovement = new PlayerMovement(this);
        _coinMovementSound = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        CoreSignals.Instance.onLevelStart += OnLevelStart;
        CoreSignals.Instance.onLevelFailed += OnLevelFailed;
        CoreSignals.Instance.onLevelSucceded += OnLevelSucceded;
    }

    private void OnDisable()
    {
        CoreSignals.Instance.onLevelStart -= OnLevelStart;
        CoreSignals.Instance.onLevelFailed -= OnLevelFailed;
        CoreSignals.Instance.onLevelSucceded -= OnLevelSucceded;
    }

    private void LateUpdate()
    {
        if (!_playerStopMovement && _levelStart && !FinishStage && !FinishStair)
        {
            _playerMovement.PlayerMove(_moveSpeed);
            if (!_coinMovementSound.isPlaying)
            {
                _coinMovementSound.Play();
            }
        }
        else if (_playerStopMovement)
        {
            _playerMovement.PlayerMoveStop();
        }
        else if (FinishStage/* && !FinishStair*/)
        {
            _playerMovement.PlayerFinishStage(MoveToStairPos,1.25f);
        }
        else if (FinishStair)
        {
            _playerMovement.PlayerFinishStageEnd(StairPos,3f);
        }

    }
    private void OnLevelFailed()
    {
        _playerStopMovement = true;
        _trailRenderer.enabled = false;
        _coinMovementSound.Stop();
    }

    private void OnLevelStart()
    {
        _levelStart = true;
        _trailRenderer.enabled = true;
    }

    public void ClimbStair()
    {
        FinishStage = false;
        FinishStair = true;
        _trailRenderer.enabled = false;
    }

    public void MoveToStair()
    {
        FinishStage = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
        _trailRenderer.enabled = false;
        _coinMovementSound.Stop();
    }

    private void OnLevelSucceded()
    {
        _playerStopMovement = true;
        FinishStair = false;
    }
}
