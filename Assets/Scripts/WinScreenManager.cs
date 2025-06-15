using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
  
    private const string Level1SceneName = "Level1";
    public Animator buttonAnimator;

    public void RestartLevel1()
    {
        Time.timeScale = 1f; 
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