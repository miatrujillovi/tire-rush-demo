using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool gameOver = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void GameOver()
    {
        gameOver = true;
        GameSpeed.speed = 0;
        Debug.Log("Game Over");
    }
}