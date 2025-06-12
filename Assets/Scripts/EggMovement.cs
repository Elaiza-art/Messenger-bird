using UnityEngine;

public class EggMovement : MonoBehaviour
{
    public float fallSpeed;

    void Start()
    {
        fallSpeed = Random.Range(2f, 5f);
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Уничтожение за пределами экрана
        if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 1)
        {
            Destroy(gameObject);
        }
    }
    
}