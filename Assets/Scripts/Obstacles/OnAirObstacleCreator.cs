using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAirObstacleCreator : ObstacleCreator, IStartCreatingObstacle
{
    [SerializeField] Transform[] _instantiatePlaces;
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] AirObstacleSO obstacleSO;

    public void StartCreatingObstacle()
    {
        _obstaclePrefab = obstacleSO.AirObstacles[Random.Range(0, obstacleSO.AirObstacles.Length)];
        CreateObstacle(_instantiatePlaces, _obstaclePrefab);
    }
}
