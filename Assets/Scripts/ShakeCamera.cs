using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Transform cameraTransform = default;
    private Vector2 _originalPosOfCam = default;
    public float shakeFrequency = default;

    private void Start()
    {
        _originalPosOfCam = cameraTransform.position;
    }
}
