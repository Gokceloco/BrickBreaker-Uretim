using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputType inputType;
    [SerializeField] private float speed;
    [SerializeField] private float maxXPos;
    [SerializeField] private float yPos;
    [SerializeField] private float sensitivity;

    private Transform selectedObj;

    private void Update()
    {
        if (inputType == InputType.Keyboard)
        {
            if (Keyboard.current.dKey.isPressed)
            {
                transform.position += Vector3.right * Time.deltaTime * speed;
            }
            if (Keyboard.current.aKey.isPressed)
            {
                transform.position += Vector3.left * Time.deltaTime * speed;
            }
        }
        else if (inputType == InputType.Mouse)
        {
            var mousePos = Mouse.current.position.ReadValue();
            transform.position = new Vector3((mousePos.x - Screen.width * .5f) * sensitivity, yPos, 0);
        }

        KeepPlayerInBounds();
    }

    private void KeepPlayerInBounds()
    {
        var xPos = Mathf.Clamp(transform.position.x, -maxXPos, maxXPos);
        transform.position = new Vector3 (xPos, yPos, 0);
    }
}

public enum InputType
{
    Keyboard,
    Mouse,
}