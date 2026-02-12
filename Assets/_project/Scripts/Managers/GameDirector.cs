using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public BallManager ballManager;

    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevelManager();
        ballManager.RestartBallManager();
    }
}
