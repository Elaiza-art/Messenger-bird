using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonCli�k : MonoBehaviour
{
    [SerializeField] private string sceneName = "Level1";
    public void onButtonCli�k ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
