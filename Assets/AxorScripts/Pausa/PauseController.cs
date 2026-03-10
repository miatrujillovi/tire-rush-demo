using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    public static PauseController instance;

    public bool inPauseZone = false;

    public float holdTimeRequired = 1.2f;

    float holdTimer;

    public GameObject pauseMenu;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!inPauseZone)
        {
            holdTimer = 0;
            return;
        }

        if (Keyboard.current.spaceKey.isPressed)
        {
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdTimeRequired)
            {
                PauseGame();
            }
        }
        else
        {
            holdTimer = 0;
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;

        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;

        pauseMenu.SetActive(false);

        holdTimer = 0;
    }
}
