using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleCreator
{
    void CreateObstacle(Transform[] InsPlaces,GameObject obstaclePrefab);
}
