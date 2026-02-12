using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public LevelManager levelManager;
    public BallManager ballManager;

    private void Start()
    {
        RestartLevel();
    }

    private void RestartLevel()
    {
        levelManager.RestartLevelManager();
        ballManager.RestartBallManager();
    }
}
