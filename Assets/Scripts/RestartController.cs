using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    // Название сцены второго уровня (должно совпадать с именем файла!)
    private const string Level2SceneName = "Level2";
    public Animator buttonAnimator;

    public void RestartLevel2()
    {
        // Сброс игровых параметров
        Time.timeScale = 1f; // На случай, если игра была на паузе

        // Дополнительные сбросы при необходимости
        // PlayerPrefs.DeleteKey("CurrentHealth");
        // ScoreManager.instance.ResetScore();

        // Загрузка второго уровня
        SceneManager.LoadScene(Level2SceneName);
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