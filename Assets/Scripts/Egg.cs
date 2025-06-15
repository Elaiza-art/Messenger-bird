using UnityEngine;

public class Egg : MonoBehaviour
{
    public AudioClip collectSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            
            ScoreManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Если яйцо упало на пол
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.EndGame();
            Destroy(gameObject);
        }
    }
}