using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool isGameOver;
    public enum Phase { start, play, end, lose, win}
    public Phase phase;
    [SerializeField] private GameObject tutorContainer;
    void Awake()
    {
        InitializeGame();
    }
   private void InitializeGame()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
        Application.targetFrameRate = 30;
    }

    void Update()
    {
        
    }

    public void NextLevel()
    {
        LevelManager.levelManager.levelData.currentLevelID++;
        if(LevelManager.levelManager.levelData.currentLevelID >= LevelManager.levelManager.Levels.Count)
        {
            LevelManager.levelManager.UpdateLevels();
        }
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void LoseGameAct()
    {
        isGameOver = true;
        phase = Phase.lose;
        UIManager.UImanager.LoseGameAct();
    }
    public void WinGameAct()
    {
        isGameOver = true;
        phase = Phase.win;
        UIManager.UImanager.WinGameAct();
    }

    public void GameStart()
    {
        tutorContainer.SetActive(false);
    }
}
