using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg"))
        {
            Destroy(other.gameObject);
            ScoreManager.Instance.LoseLife(); // Вызов конца игры
        }
    }
}