using System;
using UnityEngine;

public class BallManager : MonoBehaviour
{
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
        _currentBall = Instantiate(ballPrefab);
        _currentBall.transform.position = new Vector3(0,-2,0);
        _currentBall.StartBall();
    }
}
