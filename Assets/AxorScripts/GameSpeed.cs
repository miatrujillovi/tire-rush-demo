using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static float speed = 6f;
    public float speedIncrease = 0.05f;

    void Update()
    {
        speed += speedIncrease * Time.deltaTime;
    }
}
