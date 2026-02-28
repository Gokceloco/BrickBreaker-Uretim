using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public FXManager fXManager;

    public CameraShaker cameraShaker;

    [SerializeField] private Brick brickPrefab;
    [SerializeField] private GameObject brickSlotPrefab;

    /*[SerializeField] private int xSize;  
    [SerializeField] private int ySize;  
    [SerializeField] private int xOffset;*/

    private List<Brick> _bricksList = new List<Brick>();

    public List<Transform> brickSlotsList = new List<Transform>();

    public void RestartLevelManager()
    {
        DeleteBricks();
        CreateBricks();
    }

    /*private void CreateBrickSlots()
    {
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                var newSlot = Instantiate(brickSlotPrefab);
                newSlot.transform.position = new Vector3(i- xOffset, j, 0);
                brickSlotsList.Add(newSlot.transform);
            }
        }
    }*/

    private void CreateBricks()
    {
        var tempList = new List<Transform>(brickSlotsList);

        for (int i = 0; i < 2; i++)
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
