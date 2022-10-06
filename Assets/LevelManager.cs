using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevelID;
    public static LevelManager levelManager;
    public LevelData levelData;
    public List<LevelData.Level> Levels;


   private void Awake()
    {
        if (levelManager != null && levelManager != this)
        {
            Destroy(this);
        }
        else
        {
            levelManager = this;
        }
        InitializeLevel();
    }
    private void InitializeLevel()
    {
        currentLevelID = levelData.currentLevelID;
    }

    public void UpgradeLevel()
    {
        levelData.currentLevelID++;
    }
    public void UpdateLevels()
    {
        //  add new monsters, rock damage increase etc..
        levelData.currentLevelID = 1;
    }
} 
