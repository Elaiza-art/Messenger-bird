using UnityEngine;
using UnityEngine.UI;

public class ManualButtonSetup : MonoBehaviour
{
    void Start()
    {
        // ����� ������ �� �����
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        // �������� ���������� �������
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        });
    }
}
