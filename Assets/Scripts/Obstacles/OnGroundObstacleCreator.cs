using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundObstacleCreator : ObstacleCreator , IStartCreatingObstacle
{
    [SerializeField] Transform[] _instantiatePlaces;
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] GroundObstacleSO obstacleSO;


    public void StartCreatingObstacle()
    {
        _obstaclePrefab = obstacleSO.GroundObstacles[Random.Range(0,obstacleSO.GroundObstacles.Length)];
        CreateObstacle(_instantiatePlaces, _obstaclePrefab);
    }
}
