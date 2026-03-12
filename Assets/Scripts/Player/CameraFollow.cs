using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Follow Settings")]
    [SerializeField, Tooltip("Reference to the player in order to follow it horizontally.")] private Transform target;
    [SerializeField, Tooltip("How much off center will the camera have to move in order to not have the character in the center.")] private float cameraOffCenter = 8f;

    private void Update()
    {
        transform.position = new Vector3((target.position.x + cameraOffCenter), 1, -10);
    }
}
