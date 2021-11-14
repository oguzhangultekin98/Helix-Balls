using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int levelIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        levelIndex = PlayerPrefs.GetInt("Level", 1);
    }

    public void UpdateLevelIndex()
    {
        levelIndex++;
        PlayerPrefs.SetInt("Level", levelIndex);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("StageIndex", 0);
    }

    public int GetLevelIndex()
    {
        return (levelIndex - 1) % 3;
    }
}
