using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectedCoinMovement : MonoBehaviour , IFinishStairMovement
{
    protected internal Transform _followingTarget;
    NavMeshAgent _agent;

    public bool FinishStair { get ; set ; }
    public bool FinishStage { get; set; }
    public Vector3 StairPos { get; set; }
    public Vector3 MoveToStairPos { get; set; }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(_followingTarget != null && !FinishStage && _agent!=null)
        {
            _agent.SetDestination(_followingTarget.position);
        }
        else if(FinishStage/* && !FinishStair*/)
        {
            transform.position = Vector3.Lerp(transform.position, MoveToStairPos, 1.25f * Time.deltaTime);
        }
        else if (FinishStair)
        {
            transform.position = Vector3.MoveTowards(transform.position, StairPos, 3f * Time.deltaTime);
        }
    }

    public void ClimbStair()
    {
        FinishStage = false;
        FinishStair = true;

    }

    public void MoveToStair()
    {
        FinishStage = true;
        Destroy(_agent);
    }
}
