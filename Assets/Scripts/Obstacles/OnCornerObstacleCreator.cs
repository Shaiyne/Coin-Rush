using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCornerObstacleCreator : ObstacleCreator, IStartCreatingObstacle
{
    [SerializeField] Transform[] _instantiatePlaces;
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] CornerObstacleSO obstacleSO;

    public void StartCreatingObstacle()
    {
        _obstaclePrefab = obstacleSO.CornerObstacles[Random.Range(0, obstacleSO.CornerObstacles.Length)];
        CreateObstacle(_instantiatePlaces, _obstaclePrefab);
    }
}
