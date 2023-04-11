using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTypeSelecter : MonoBehaviour
{
    [SerializeField] GameObject[] _obstacleType;
    [SerializeField] GameObject _obstacles;
    IStartCreatingObstacle _iObstacleCreator;
    private void Awake()
    {
        _obstacles = _obstacleType[Random.Range(0, _obstacleType.Length)].gameObject;
        _iObstacleCreator = _obstacles.GetComponent<IStartCreatingObstacle>();
    }
    private void Start()
    {
        this.Wait(1, () =>
        {
            _iObstacleCreator.StartCreatingObstacle();
        });
    }
}
