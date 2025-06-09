using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 9.0f;
    [SerializeField]
    private int damage = -1;
    private Vector3 moveVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveVector = new Vector3(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveVector * Time.deltaTime);
        if (transform.position.x > 9.31)
        {
            Destroy(gameObject);
        }
    }
}
