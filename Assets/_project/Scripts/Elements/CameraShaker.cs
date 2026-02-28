using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraShaker : MonoBehaviour
{
    public void ShakeCamera(float magnitude, float duration)
    {
        transform.DOKill();
        transform.position = new Vector3(0, 0, -10);
        transform.DOShakePosition(duration, magnitude);
    }

    private void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            ZoomIn();
            ShakeCamera(.2f,.5f);
            ZoomOut(.25f);
        }
    }

    public void ZoomIn()
    {
        GetComponent<Camera>().DOOrthoSize(3, .25f);
    }
    public void ZoomOut(float delay)
    {
        GetComponent<Camera>().DOOrthoSize(5, .25f).SetDelay(delay);
    }
}
