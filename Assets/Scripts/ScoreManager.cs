using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    public static ScoreManager Instance;
    public enum GameState { Playing, GameOver }
    public GameState currentState;
    public int scoreToWin = 30;

    [Header("Hearts Settings")]
    public Image[] hearts; // Массив изображений сердец
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool isGameActive = true;

    private int lives = 3;

    void Awake()
    {
        // Синглтон паттерн с улучшенной обработкой
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        UpdateHearts();
    }

    void Start()
    {
        UpdateScoreText();
        
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        if (score >= scoreToWin)
        {
            WinGame();
        }
    }
    void WinGame()

    {
        isGameActive = false;
        // Сохраняем результаты если нужно
        PlayerPrefs.SetInt("LastScore", score);
        // 1. Устанавливаем флаг окончания игры
        isGameActive = false;

        // 2. Останавливаем спавн яиц
        EggSpawner spawner = FindObjectOfType<EggSpawner>();
        if (spawner != null)
        {
            spawner.StopSpawning();
            Destroy(spawner); // Дополнительная гарантия
        }

        // 3. Уничтожаем все существующие яйца
        GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg");
        foreach (GameObject egg in eggs)
        {
            if (egg != null) Destroy(egg);
        }

        // 4. Останавливаем время (опционально)
        Time.timeScale = 0f;

        // Загружаем сцену победы
        SceneManager.LoadScene("WinScene");
    }

    public void LoseLife()
    {
        if (lives <= 0) return;

        lives--;
        UpdateHearts();

        if (lives <= 0)
        {
            EndGame();
        }
    }

    void UpdateHearts()
    {
        if (hearts == null || hearts.Length < lives)
        {
            Debug.LogWarning("Hearts array not properly configured!");
            return;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                hearts[i].sprite = (i < lives) ? fullHeart : emptyHeart;
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
        else
        {
            Debug.LogWarning("Score Text reference is missing!");
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
      
            PlayerPrefs.SetInt("LastScore", score);

          
        EggSpawner spawner = FindObjectOfType<EggSpawner>();
        if (spawner != null) spawner.StopSpawning();
        // 2. Уничтожение всех яиц
        GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg");
        foreach (GameObject egg in eggs)
        {
            Destroy(egg);
        }

        // 3. Дополнительная гарантия
        CancelInvoke("SpawnEgg"); // Если использовали InvokeRepeating
        Time.timeScale = 0f; // Полная остановка физики

        // 4. Переход на сцену
        SceneManager.LoadScene("GameOverL2");


    }
  
}
