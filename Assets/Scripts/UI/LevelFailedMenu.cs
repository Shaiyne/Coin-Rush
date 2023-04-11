using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailedMenu : UIBase
{
    [SerializeField] Button _restartLevelButton;
    [SerializeField] Button _closeGameButton;

    private void OnEnable()
    {
        _restartLevelButton.onClick.AddListener(RestartButton);
        _closeGameButton.onClick.AddListener(CloseGameButton);
    }
    private void OnDisable()
    {
        _restartLevelButton.onClick.RemoveListener(RestartButton);
        _closeGameButton.onClick.RemoveListener(CloseGameButton);
    }

    private void RestartButton()
    {
        CoreSignals.Instance.onRestartLevel?.Invoke();
        ClickSound();
    }

}
