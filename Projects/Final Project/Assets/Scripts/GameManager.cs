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
    public TextMeshProUGUI finalScoreText;
    public GameObject startPanel;
    public GameObject pausePanel;

    public bool gameEnded = false;
    public bool isPaused = false;
    public bool gameStarted = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        gameStarted = false;

        if (startPanel != null)
            startPanel.SetActive(true);

        UpdateScoreText();
        UpdateTimerText();

        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded || !gameStarted)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (isPaused)
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
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void EndGame()
{
    gameEnded = true;

    if (gameOverText != null)
    {
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over\nFinal Score: " + score;
    }

    Debug.Log("Game Over!");
}

    public void TogglePause()
    {
        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        isPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        gameStarted = true;

        if (startPanel != null)
            startPanel.SetActive(false);

        Time.timeScale = 1f;
    }
}