using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    int score;
    int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        score = Mathf.FloorToInt(GameManager.instance.distanceTravelled);

        scoreText.text = "SCORE " + score.ToString("00000");

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text = "HIGH " + highScore.ToString("00000");
    }
}
