using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCoinCreator : MonoBehaviour
{
    [SerializeField] GameObject _coinPrefab;
    [SerializeField] Transform[] _coinInsPlaces;

    private void OnEnable()
    {
        CoreSignals.Instance.onLevelStart += OnLevelStart;
    }
    private void OnDisable()
    {
        CoreSignals.Instance.onLevelStart -= OnLevelStart;
    }

    private void OnLevelStart()
    {
        for (int i = 0; i < _coinInsPlaces.Length; i++)
        {
            GameObject createdCoins = Instantiate(_coinPrefab);
            createdCoins.transform.position = _coinInsPlaces[i].GetChild(Random.Range(0,3)).transform.position;
            createdCoins.transform.rotation = _coinInsPlaces[i].transform.rotation;
            createdCoins.transform.position = new Vector3(createdCoins.transform.position.x,0.25f,createdCoins.transform.position.z);
        }
    }
}
