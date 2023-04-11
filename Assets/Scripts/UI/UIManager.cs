using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _levelSuccededMenu;
    [SerializeField] GameObject _startingLevelMenu;
    [SerializeField] GameObject _LevelFailedMenu;

    private void OnEnable()
    {
        CoreSignals.Instance.onLevelSucceded += OnLevelSucceded;
        CoreSignals.Instance.onLevelFailed += OnLevelFailed;
    }


    private void OnDisable()
    {
        CoreSignals.Instance.onLevelFailed -= OnLevelFailed;
        CoreSignals.Instance.onLevelSucceded -= OnLevelSucceded;
    }

    private void OnLevelSucceded()
    {
        _levelSuccededMenu.SetActive(true);
    }

    private void OnLevelFailed()
    {
        _LevelFailedMenu.SetActive(true);
    }

}
