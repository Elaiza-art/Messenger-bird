using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // �������� �� public static � ������� ����� ��� consistency
    public static GameManager Instance;
  

    void Awake()
    {
        // �������� �������
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
        Debug.Log("Game Over! ���� �����!");
       
    }
}
