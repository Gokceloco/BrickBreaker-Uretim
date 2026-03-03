using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public BallManager ballManager;
    public Player player;

    public UIManager uIManager;

    private void Start()
    {
        uIManager.ShowMainMenu();
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        levelManager.RestartLevelManager();
        ballManager.RestartBallManager();
        player.RestartPlayer();
    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt("LastLevelReached", levelManager.levelNo + 1);
        uIManager.ShowVictoryUI();
        ballManager.StopBall();
    }

    public void LoadNextLevel()
    {
        levelManager.levelNo++;
        RestartLevel();
    }

    public void LevelFailed()
    {
        uIManager.ShowFailUI();
    }
}
