using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    void Update()
    {
        if (!GameManager.gameOver)
        {
            transform.position += Vector3.left * GameSpeed.speed * Time.deltaTime;
        }
    }
}
