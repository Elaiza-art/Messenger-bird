using UnityEngine;

public class AngryBirrd : MonoBehaviour
{
    [SerializeField]
    private float speed = 9.0f;
    private Vector3 moveVector;
    private float randomSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomSpeed = Random.Range(2.3f, speed);
        moveVector = new Vector3(-randomSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector * Time.deltaTime);
        if (transform.position.x < -13)
        {
            Destroy(gameObject);
        }
    }
}
