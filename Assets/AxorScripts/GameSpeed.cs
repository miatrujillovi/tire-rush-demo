using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed instance;

    public static float speed = 6f;
    public float speedIncrease = 0.05f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Update()
    {
        speed += speedIncrease * Time.deltaTime;
    }

    public void SlowSpeed(float _slowMultiplier)
    {
        speed *= _slowMultiplier;
    }
}
