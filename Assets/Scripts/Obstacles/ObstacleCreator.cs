using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleCreator : MonoBehaviour , IObstacleCreator
{
    public void CreateObstacle(Transform[] InsPlaces,GameObject obstaclePrefab)
    {
        for (int i = 0; i < InsPlaces.Length; i++)
        {
            int rndmNumber = Random.Range(0, InsPlaces[i].childCount);
            GameObject obstacleIns = Instantiate(obstaclePrefab);
            obstacleIns.transform.position = InsPlaces[i].GetChild(rndmNumber).transform.position;
            obstacleIns.transform.eulerAngles = InsPlaces[i].GetChild(rndmNumber).transform.eulerAngles + obstacleIns.transform.eulerAngles;
        }
    }
}
