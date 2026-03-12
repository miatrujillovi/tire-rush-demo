using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float speed = 6f;
    public float maxSpeed = 18f;
    public float acceleration = 0.02f;
    [Space]
    [Header("Game Over References")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private CharacterController characterController;
    [Space]
    public float distanceTravelled;
    public bool gameOver = false;

    private InputActionReference jumpAction;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        jumpAction = characterController.jumpAction;
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

        if (gameOver)
        {
            GameOver();
            if (jumpAction.action.WasPressedThisFrame())
            {
                RestartGame();
            }
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        characterController.enabled = false;
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        characterController.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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