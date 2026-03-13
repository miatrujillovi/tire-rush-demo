using System.Collections;
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
    [SerializeField] private CharacterAnimations characterAnimations;
    [SerializeField] private GameObject scoreScreen;
    [SerializeField] private MenuAnimation menuAnimation;
    [SerializeField] private CameraShake cameraShake;
    [Space]
    public float distanceTravelled;
    public bool gameOver = false;
    bool gameOverSoundPlayed = false;

    private InputActionReference jumpAction;

    public bool gameStarted = false; // NUEVO
    public GameObject startText;     // Texto "Presiona Space"
    Coroutine slowRoutine;

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

                AudioManager.Instance.PlayGameStart();
                /*if (startText != null)
                    startText.SetActive(false);*/
            }

            return;
        }

        // Lógica normal del juego
        if (!gameOver)
        {
            menuAnimation.DisappearObjectsFromMain();
            scoreScreen.SetActive(true);
            characterAnimations.StartRotation();
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
        characterAnimations.StopRotation();
        gameOverScreen.SetActive(true);
        characterController.enabled = false;

        if (!gameOverSoundPlayed)
        {
            AudioManager.Instance.PlayGameOver();
            gameOverSoundPlayed = true;
        }
    }

    public void RestartGame()
    {
        scoreScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        characterController.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SlowSpeed(float _slowMultiplier, float duration)
    {
        cameraShake.Shake(1f, 0.3f);

        if (slowRoutine != null)
            StopCoroutine(slowRoutine);

        slowRoutine = StartCoroutine(SlowSpeedCoroutine(_slowMultiplier, duration));
    }

    IEnumerator SlowSpeedCoroutine(float slowMultiplier, float duration)
    {
        speed *= slowMultiplier;

        yield return new WaitForSeconds(duration);
    }

    public int GetDifficulty()
    {
        if (distanceTravelled < 200)
            return 0;

        if (distanceTravelled < 500)
            return 1;

        return 2;
    }

    public void ReduceScore(float amount)
    {
        distanceTravelled -= amount;

        if (distanceTravelled < 0)
            distanceTravelled = 0;
    }
}