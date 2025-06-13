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

    [Header("Hearts Settings")]
    public Image[] hearts; // ������ ����������� ������
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int lives = 3;

    void Awake()
    {
        // �������� ������� � ���������� ����������
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

            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        EggSpawner spawner = FindObjectOfType<EggSpawner>();
        if (spawner != null) spawner.StopSpawning();
        // 2. ����������� ���� ���
        GameObject[] eggs = GameObject.FindGameObjectsWithTag("Egg");
        foreach (GameObject egg in eggs)
        {
            Destroy(egg);
        }

        // 3. �������������� ��������
        CancelInvoke("SpawnEgg"); // ���� ������������ InvokeRepeating
        Time.timeScale = 0f; // ������ ��������� ������

        // 4. ������� �� �����
        SceneManager.LoadScene("GameOver");


    }
}
