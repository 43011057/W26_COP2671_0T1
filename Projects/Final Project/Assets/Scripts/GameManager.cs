using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public float timeLeft = 60f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;

    public bool gameEnded = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateScoreText();
        UpdateTimerText();

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (gameEnded)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            EndGame();
        }

        UpdateTimerText();
    }

    public void AddScore(int amount)
    {
        if (gameEnded)
            return;

        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void EndGame()
    {
        gameEnded = true;

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        Debug.Log("Game Over!");
    }
}