using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  
    public static GameManager Instance;
  

    void Awake()
    {
        // Синглтон паттерн
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void EndGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Game Over! Яйцо упало!");
       
    }


}
