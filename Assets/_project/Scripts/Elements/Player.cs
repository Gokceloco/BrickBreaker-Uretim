using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxXPos;
    [SerializeField] private float yPos;

    private void Update()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }

        KeepPlayerInBounds();
    }

    private void KeepPlayerInBounds()
    {
        var xPos = Mathf.Clamp(transform.position.x, -maxXPos, maxXPos);
        transform.position = new Vector3 (xPos, yPos, 0);
    }
}
