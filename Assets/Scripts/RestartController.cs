using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
  
    private const string Level2SceneName = "Level2";
    public Animator buttonAnimator;

    public void RestartLevel2()
    {
        Time.timeScale = 1f; 

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