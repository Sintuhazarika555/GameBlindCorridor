using UnityEngine;

public class camera : MonoBehaviour
{
    [Header("Design Target Settings")]
    [Tooltip("The total width of your border/maze in Unity world units")]
    public float targetBoundsWidth = 0.7f;

    private Camera _cam;

    void Awake()
    {
        _cam = GetComponent<Camera>();
        AdjustCameraSize();
    }

    void Update()
    {
#if UNITY_EDITOR
        AdjustCameraSize();
#endif
    }

    void AdjustCameraSize()
    {
        if (_cam == null || !_cam.orthographic) return;

        // Calculate the camera's orthographic size required to fit targetBoundsWidth across any screen aspect ratio
        float unitsPerPixel = targetBoundsWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        _cam.orthographicSize = desiredHalfHeight;
    }
}
