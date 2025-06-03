using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    public void EndGame()
    {
        // Вариант 1: Перезагрузка сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Вариант 2: Вывод сообщения
        Debug.Log("Game Over! Яйцо упало!");

        // Вариант 3: Активация UI панели (нужен Canvas)
        // gameOverPanel.SetActive(true);
    }
}