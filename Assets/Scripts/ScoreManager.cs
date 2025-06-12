using UnityEngine;
using TMPro; // �����: ���������� ������������ ��� TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // ������ �� TextMeshPro-���������
    private int score = 0;

    void Start()
    {
        UpdateScoreText(); // ������������� ������ ��� ������
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}"; // ��������� �����
    }
}