using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public FXManager fXManager;

    public Ball ballPrefab;

    private Ball _currentBall;

    public Sprite ballSprite1;
    public Sprite ballSprite2;

    public void RestartBallManager()
    {
        DeleteBall();
        CreateBall();
    }

    private void DeleteBall()
    {
        if (_currentBall != null)
        {
            Destroy(_currentBall.gameObject);
        }
    }

    private void CreateBall()
    {
        _currentBall = Instantiate(ballPrefab, transform);
        _currentBall.transform.position = new Vector3(0,-2,0);
        _currentBall.StartBall();
    }

    public void StopBall()
    {
        _currentBall.StopBall();
    }

    public void BallDestroyed()
    {
        var remainingHealth = gameDirector.player.ReduceHealth();
        if (remainingHealth > 0) 
        {
            CreateBall();
        }
        else
        {
            gameDirector.LevelFailed();
        }
    }
}
