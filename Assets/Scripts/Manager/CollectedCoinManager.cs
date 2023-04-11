using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoinManager : MonoBehaviour
{
    [SerializeField] GameObject _collebtibleCoinPrefab;
    [SerializeField] List<GameObject> _collectedGameObjects = new List<GameObject>();
    int _collectedGameObjectsCount = 0;
    bool _checkYPositionReady;
    Transform player;
    Vector3 FinishYPosition;
    float _planeZLenght;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        _planeZLenght = SaveGameManager.GetPlanePosZLenght();
    }
    private void OnEnable()
    {
        PlayerSignals.Instance.onCollectibleCoinContact += OnCollectedCoinCreate;
        PlayerSignals.Instance.onFinishArch += OnFinishArch;
        PlayerSignals.Instance.onFinishStair += OnFinishStair;
        CoreSignals.Instance.onLevelSucceded += OnLevelSucceded;
    }


    private void OnDisable()
    {
        PlayerSignals.Instance.onCollectibleCoinContact -= OnCollectedCoinCreate;
        PlayerSignals.Instance.onFinishArch -= OnFinishArch;
        PlayerSignals.Instance.onFinishStair -= OnFinishStair;
        CoreSignals.Instance.onLevelSucceded -= OnLevelSucceded;
    }
    private void Update()
    {
        if(_checkYPositionReady)
        {
            IsAligmentYPositionFinish();
        }
    }
    private void OnCollectedCoinCreate(Transform getTransform)
    {
        if (_collectedGameObjectsCount == 0)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            GameObject collectedCreted = Instantiate(_collebtibleCoinPrefab, player.transform.position
            +
            new Vector3(0, 0, -0.8f), Quaternion.identity);
            collectedCreted.GetComponent<CollectedCoinMovement>()._followingTarget = GameObject.FindGameObjectWithTag("Player").transform;
            _collectedGameObjects.Add(collectedCreted);
            _collectedGameObjectsCount++;
        }
        else
        {
            GameObject collectedCreted = Instantiate(_collebtibleCoinPrefab, _collectedGameObjects[_collectedGameObjectsCount - 1].transform.position
            +
            new Vector3(0, 0, -0.8f), Quaternion.identity);
            _collectedGameObjects.Add(collectedCreted);
            _collectedGameObjectsCount++;
            _collectedGameObjects[_collectedGameObjects.Count-1].GetComponent<CollectedCoinMovement>()._followingTarget = _collectedGameObjects[_collectedGameObjectsCount - 2].transform;
        }

    }
    private void OnFinishArch()
    {
        int counter = 0;
        player.GetComponent<IFinishStairMovement>().MoveToStair();

        player.GetComponent<IFinishStairMovement>().MoveToStairPos = 
            new Vector3(0, 0.25f + (_collectedGameObjectsCount * 0.5f), 
            ((GameManager.Instance.PlaneCounter + 1) * _planeZLenght) + SaveGameManager.GetFinalArcPosZ());

        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0, player.transform.eulerAngles.z);
        for (int i = _collectedGameObjects.Count - 1; 0 <= i; i--)
        {
            _collectedGameObjects[i].GetComponent<IFinishStairMovement>().MoveToStair();

            _collectedGameObjects[i].GetComponent<IFinishStairMovement>().MoveToStairPos =
                new Vector3(0, 0.25f + (counter * 0.5f), 
                ((GameManager.Instance.PlaneCounter + 1) * _planeZLenght) + SaveGameManager.GetFinalArcPosZ());

            _collectedGameObjects[i].transform.eulerAngles = new Vector3(_collectedGameObjects[i].transform.eulerAngles.x, 0, _collectedGameObjects[i].transform.eulerAngles.z);
            counter++;
            if (i == 0)
            {
                _checkYPositionReady = true;
            }
        }

    }
    private void OnFinishStair()
    {
        int counter = 0;
        player.GetComponent<IFinishStairMovement>().ClimbStair();

        player.GetComponent<IFinishStairMovement>().StairPos = 
            new Vector3(0, 0.25f + (_collectedGameObjectsCount * 0.5f), 
            ((SaveGameManager.GetPlaneCounts() + 1) * _planeZLenght) + SaveGameManager.GetFinalStairPosZ() + (1f * _collectedGameObjects.Count));

        for (int i = _collectedGameObjects.Count - 1; 0 <= i; i--)
        {
            _collectedGameObjects[i].GetComponent<IFinishStairMovement>().ClimbStair();

            _collectedGameObjects[i].GetComponent<IFinishStairMovement>().StairPos =
                new Vector3(0, 0.25f + (counter * 0.5f), 
                ((SaveGameManager.GetPlaneCounts()+1)* _planeZLenght) + SaveGameManager.GetFinalStairPosZ() + (1f * counter));

            counter++;
        }
    }
    private void IsAligmentYPositionFinish()
    {
        FinishYPosition = 
            new Vector3(0, 0.25f + (_collectedGameObjectsCount * 0.5f), 
            ((GameManager.Instance.PlaneCounter + 1) * _planeZLenght) + SaveGameManager.GetFinalArcPosZ());

        if (Vector3.Distance(player.transform.position, FinishYPosition) < 1f && _checkYPositionReady)
        {
            PlayerSignals.Instance.onFinishStair?.Invoke();
            _checkYPositionReady = false;
        }
    }
    private void OnLevelSucceded()
    {
        GameManager.Instance.LevelCollectedScore = _collectedGameObjects.Count * 10;
    }

}
