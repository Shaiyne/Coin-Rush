using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSuccededMenu : UIBase
{
    [SerializeField] Button _nextLevelButton;
    [SerializeField] Button _closeGamebutton;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _allScoreText;

    private void OnEnable()
    {
        _nextLevelButton.onClick.AddListener(NextLevelButton);
        _closeGamebutton.onClick.AddListener(CloseGameButton);
    }
    private void OnDisable()
    {
        _nextLevelButton.onClick.RemoveListener(NextLevelButton);
        _nextLevelButton.onClick.RemoveListener(CloseGameButton);
    }
    private void Update()
    {
        _scoreText.text = " SCORE " + GameManager.Instance.LevelCollectedScore.ToString();
        _allScoreText.text = " All SCORE = " + SaveGameManager.GetAllCollectedCoinScore().ToString();
    }
    private void NextLevelButton()
    {
        CoreSignals.Instance.onNextLevel?.Invoke();
        ClickSound();
    }
}
