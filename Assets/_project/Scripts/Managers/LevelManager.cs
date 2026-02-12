using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Brick brickPrefab;

    private Brick _currentBrick;
    public void RestartLevelManager()
    {
        DeleteBricks();
        CreateBricks();
    }

    private void CreateBricks()
    {
        _currentBrick = Instantiate(brickPrefab);
        _currentBrick.transform.position = new Vector3(0, 2, 0);
        _currentBrick.StartBrick();
    }

    private void DeleteBricks()
    {
        if (_currentBrick != null)
        {
            Destroy(_currentBrick.gameObject);
        }
    }
}
