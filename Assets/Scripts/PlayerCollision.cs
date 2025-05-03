using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public ScoreManager scoreManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Egg"))
        {
            Destroy(other.gameObject);
            scoreManager.AddScore(1);
        }
    }
}