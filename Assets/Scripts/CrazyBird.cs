using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float screenWidth;
    private bool isFacingRight = true; // Направление взгляда птички

    void Start()
    {
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float newX = Mathf.Clamp(transform.position.x + move, -screenWidth, screenWidth);
        transform.position = new Vector2(newX, transform.position.y);

        // Поворот птички
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Меняем направление
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Инвертируем по оси X
        transform.localScale = scale;
    }
}