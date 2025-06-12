using UnityEngine;
using TMPro; // Важно: используем пространство имён TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Ссылка на TextMeshPro-компонент
    private int score = 0;

    void Start()
    {
        UpdateScoreText(); // Инициализация текста при старте
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}"; // Обновляем текст
    }
}