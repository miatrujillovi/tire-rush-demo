using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;

    public void GameOver()
    {
        gameOver = true;
        GameSpeed.speed = 0;
    }
}