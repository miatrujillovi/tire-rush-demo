using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float speed = 6f;
    public float maxSpeed = 18f;
    public float acceleration = 0.02f;

    public float distanceTravelled;
    public bool gameOver = false;

    public bool gameStarted = false; // NUEVO
    public GameObject startText;     // Texto "Presiona Space"

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
        // Esperar a que el jugador presione Space
        if (!gameStarted)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                gameStarted = true;

                if (startText != null)
                    startText.SetActive(false);
            }

            return;
        }

        // Lógica normal del juego
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