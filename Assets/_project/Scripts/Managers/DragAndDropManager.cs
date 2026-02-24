using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDropManager : MonoBehaviour
{
    private GameObject _selectedObject;
    public LayerMask cardLayerMask;
    public LayerMask slotLayerMask;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            DragStarted(ray);
        }

        if (Mouse.current.leftButton.isPressed)
        {
            Dragged(ray);
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            DragReleased(ray);
        }
    }

    private void DragReleased(Ray ray)
    {
        var slot = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, slotLayerMask);
        if (slot.collider != null)
        {
            _selectedObject.transform.position = slot.collider.transform.position;
        }
        _selectedObject = null;
    }

    private void Dragged(Ray ray)
    {
        if (_selectedObject != null)
        {
            var pos = ray.origin + ray.direction * -Camera.main.transform.position.z;
            pos.z = 0;
            _selectedObject.transform.position = pos; 
        }
    }

    private void DragStarted(Ray ray)
    {
        var selection = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, cardLayerMask);
        if (selection.collider != null)
        {
            _selectedObject = selection.collider.gameObject;
        }
        else
        {
            _selectedObject = null;
        }
    }
}
