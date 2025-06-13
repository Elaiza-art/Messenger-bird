using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager1 : MonoBehaviour
{
    public int scoreCounter = 0;
    [SerializeField]
    private TextMeshProUGUI score;
    void Start()
    {
        score.text = "—чет: " + scoreCounter;
    }

    public void addToScore()
    { 
        scoreCounter++;
        score.text = "—чет: " + scoreCounter;
    }
}