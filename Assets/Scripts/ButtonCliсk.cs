using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonCliñk : MonoBehaviour
{
    [SerializeField] private string sceneName = "Level1";
    public void onButtonCliñk ()
    {
        SceneManager.LoadScene(sceneName);
    }
}
