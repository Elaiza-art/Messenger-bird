using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
  
    private const string Level1SceneName = "Level1";
    public Animator buttonAnimator;

    public void RestartLevel1()
    {
        // Сброс игровых параметров
        Time.timeScale = 1f; // На случай, если игра была на паузе

        // Дополнительные сбросы при необходимости
        // PlayerPrefs.DeleteKey("CurrentHealth");
        // ScoreManager.instance.ResetScore();

        // Загрузка второго уровня
        SceneManager.LoadScene(Level1SceneName);
    }

    public void OnButtonHover()
    {
        buttonAnimator.Play("Hover");
    }

    public void OnButtonExit()
    {
        buttonAnimator.Play("Normal");
    }
}