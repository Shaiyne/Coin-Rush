using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : UIBase
{
    [SerializeField] Button _startButton;
    [SerializeField] Button _closeGameButton;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartButton);
        _closeGameButton.onClick.AddListener(CloseGameButton);
    }
    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartButton);
        _closeGameButton.onClick.RemoveListener(CloseGameButton);
    }

    private void StartButton()
    {
        CoreSignals.Instance.onStartGame?.Invoke();
    }
}
