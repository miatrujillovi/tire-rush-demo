using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float speed = 6f;
    public float maxSpeed = 18f;
    public float acceleration = 0.02f;

    public float distanceTravelled;
    public bool gameOver = false;

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
        if (!gameOver)
        {
            if (speed < maxSpeed)
                speed += acceleration * Time.deltaTime;

            distanceTravelled += speed * Time.deltaTime;
        }
    }

    public void SlowSpeed(float _slowMultiplier)
    {
        speed *= _slowMultiplier;
    }

    public int GetDifficulty()
    {
        if (distanceTravelled < 200)
            return 0;

        if (distanceTravelled < 500)
            return 1;

        return 2;
    }
}