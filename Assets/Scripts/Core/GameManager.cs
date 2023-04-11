using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] bool GameStartBool;
    public int LevelCollectedScore;
    public int LevelNumber;
    public int PlaneCounter;

    private void Awake()
    {
        SaveGameManager.LoadGame();
        this.Wait(0.1f, () => // Loading Data Time
        {
            LevelNumber = SaveGameManager.CurrentSaveData.LevelData.LevelScore;
            PlaneCounter = SaveGameManager.CurrentSaveData.LevelData.PlaneCount;
        });
        //this.Wait(1, () =>
        //{
        //    CoreSignals.Instance.onLevelStart?.Invoke();
        //});
    }
    private void OnEnable()
    {
        CoreSignals.Instance.onLevelSucceded += OnLevelSucceded;
        CoreSignals.Instance.onCloseGame += OnCloseGame;
        CoreSignals.Instance.onRestartLevel += OnRestartLevel;
        CoreSignals.Instance.onNextLevel += OnNextLevel;
        CoreSignals.Instance.onStartGame += OnStartGame;
    }


    private void OnDisable()
    {
        CoreSignals.Instance.onLevelSucceded -= OnLevelSucceded;
        CoreSignals.Instance.onCloseGame -= OnCloseGame;
        CoreSignals.Instance.onRestartLevel -= OnRestartLevel;
        CoreSignals.Instance.onNextLevel -= OnNextLevel;
        CoreSignals.Instance.onStartGame -= OnStartGame;
    }

    private void PlaneCounterCalculator()
    {
        if (LevelNumber % 4 == 0)
        {
            SaveGameManager.CurrentSaveData.LevelData.PlaneCount += 1;
        }
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void OnLevelSucceded()
    {
        PlaneCounterCalculator();
        this.Wait(0.2f, () => // CollectedCoinManager set waiting LevelCollectedScore
        {
            SaveGameManager.CurrentSaveData.LevelData.LevelScore += 1;
            SaveGameManager.CurrentSaveData.PointData.AllScore += LevelCollectedScore;
            SaveGameManager.SaveGame();
        });
    }
    private void OnNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCloseGame()
    {
        Application.Quit();
    }
}
