using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Brick brickPrefab;

    private List<Brick> _bricksList = new List<Brick>();

    public List<Transform> brickSlotsList = new List<Transform>();

    public void RestartLevelManager()
    {
        DeleteBricks();
        CreateBricks();
    }

    private void CreateBricks()
    {
        var tempList = new List<Transform>(brickSlotsList);

        for (int i = 0; i < 15; i++)
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
    }
}
