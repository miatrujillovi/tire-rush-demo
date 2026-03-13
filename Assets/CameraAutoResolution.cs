using UnityEngine;

public class CameraAutoResolution : MonoBehaviour
{
    public float targetAspect = 16f / 9f;
    public float baseOrthographicSize = 5f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        UpdateCamera();
    }

    void Update()
    {
        UpdateCamera();
    }

    void UpdateCamera()
    {
        float screenAspect = (float)Screen.width / Screen.height;
        float difference = targetAspect / screenAspect;

        if (difference > 1f)
        {
            cam.orthographicSize = baseOrthographicSize * difference;
        }
        else
        {
            cam.orthographicSize = baseOrthographicSize;
        }
    }
}
