using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public float tileWidth = 20f;
    public float resetPositionX = -20f;
    public float tilesAhead = 3;

    void Update()
    {
        if (transform.position.x < resetPositionX)
        {
            float newX = transform.position.x + tileWidth * tilesAhead;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
