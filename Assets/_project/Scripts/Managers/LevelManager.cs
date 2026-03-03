using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public FXManager fXManager;

    public CameraShaker cameraShaker;

    [SerializeField] private Brick brickPrefab;
    [SerializeField] private GameObject brickSlotPrefab;

    private List<Brick> _bricksList = new List<Brick>();

    public List<Transform> brickSlotsList = new List<Transform>();

    public int levelNo;
    public int startBrickCount;

    private void Update()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            var tempList = new List<Brick>(_bricksList);
            foreach (var b in tempList)
            {
                b.GetHit(10);
            }
        }
    }

    public void RestartLevelManager()
    {
        levelNo = Mathf.Max(1, PlayerPrefs.GetInt("LastLevelReached"));
        DeleteBricks();
        CreateBricks();
    }

    private void CreateBricks()
    {
        var tempList = new List<Transform>(brickSlotsList);

        for (int i = 0; i < startBrickCount; i++)
        {
            var newBrick = Instantiate(brickPrefab, transform);
            newBrick.transform.position = GetBrickPosition(tempList);
            newBrick.StartBrick();
            _bricksList.Add(newBrick);
        }
    }

    private Vector3 GetBrickPosition(List<Transform> tempList)
    {      
        var selectedSlot = tempList[Random.Range(0, tempList.Count)];
        tempList.Remove(selectedSlot);
        return selectedSlot.transform.position;
    }

    private void DeleteBricks()
    {
        foreach (var b in _bricksList)
        {
            Destroy(b.gameObject);
        }
        _bricksList.Clear();
    }

    public void BrickDestroyed(Brick brick)
    {
        _bricksList.Remove(brick);
        if (_bricksList.Count <= 0)
        {
            gameDirector.LevelCompleted();
        }
    }
}
