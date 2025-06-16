using UnityEngine;
using UnityEngine.UI;

public class ManualButtonSetup : MonoBehaviour
{
    void Start()
    {
        // Найти кнопку по имени
        Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

        // Добавить обработчик вручную
        exitButton.onClick.AddListener(() =>
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        });
    }
}
