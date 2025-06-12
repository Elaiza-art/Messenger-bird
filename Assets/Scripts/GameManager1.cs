using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public void onGameStart()
    {
        SceneManager.LoadScene("Level1");
    }
    public void onGameRestart()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void onLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

}
