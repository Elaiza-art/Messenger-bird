using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager1 : MonoBehaviour
{
    public int scoreCounter = 0;
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    public int winScore = 25;
    void Start()
    {
        score.text = "—чет: " + scoreCounter + " / 25";
    }

    public void addToScore()
    {
        scoreCounter++;
        score.text = "—чет: " + scoreCounter + " / 25";
        if (scoreCounter >= winScore)
        {
            LoadNextLevel();
        }
    }
    void LoadNextLevel()
    {
        SceneManager.LoadScene("Cutscene_Level1");
    }
}
