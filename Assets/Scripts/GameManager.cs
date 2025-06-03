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
        // ������� 1: ������������ �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // ������� 2: ����� ���������
        Debug.Log("Game Over! ���� �����!");

        // ������� 3: ��������� UI ������ (����� Canvas)
        // gameOverPanel.SetActive(true);
    }
}