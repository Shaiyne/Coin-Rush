using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveGameManager
{
    public static SaveData CurrentSaveData = new SaveData();

    public const string SaveDirectory = "/Saves/";

    public const string FileName = "SaveData.sav";


    public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + SaveDirectory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (!File.Exists(dir + FileName))
        {
            CurrentSaveData.LevelData.LevelScore = 1;
            CurrentSaveData.LevelData.PlaneCount = 4;
            CurrentSaveData.PointData.AllScore = 0;
            CurrentSaveData.FinalStageData.FinalStairPosZ = 10f;
            CurrentSaveData.FinalStageData.FinalArcPosZ = 5f;
            CurrentSaveData.LevelData.PlanePosZLenght = 20f;
        }
        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FileName, json);

        GUIUtility.systemCopyBuffer = dir;
        return true;
    }
    public static void LoadGame()
    {
        var dir = Application.persistentDataPath + SaveDirectory;
        if (!File.Exists(dir + FileName))
        {
            SaveGame();
        }
        string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
        SaveData tempData = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.Log("Save file does not exists");
        }

        CurrentSaveData = tempData;
    }
    public static void NewGameSave()
    {
        var dir = Application.persistentDataPath + SaveDirectory;
        if (Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (File.Exists(dir + FileName))
        {
            File.Delete(dir + FileName);

        }
    }
    public static float GetFinalArcPosZ()
    {
        return CurrentSaveData.FinalStageData.FinalArcPosZ;
    }
    public static float GetFinalStairPosZ()
    {
        return CurrentSaveData.FinalStageData.FinalStairPosZ;
    }
    public static int GetLevel()
    {
        return CurrentSaveData.LevelData.LevelScore;
    }
    public static int GetAllCollectedCoinScore()
    {
        return CurrentSaveData.PointData.AllScore;
    }
    public static int GetPlaneCounts()
    {
        return CurrentSaveData.LevelData.PlaneCount;
    }
    public static float GetPlanePosZLenght()
    {
        return CurrentSaveData.LevelData.PlanePosZLenght;
    }
}