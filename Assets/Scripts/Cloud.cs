using UnityEngine;
using UnityEngine.U2D;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float speed =9.0f;
    private Vector3 moveVector;
    private float randomSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomSpeed = Random.Range(2.3f, speed);
        Color color = gameObject.GetComponent<SpriteRenderer>().color;
        color.a = (randomSpeed / 10) + 0.1f;
        gameObject.GetComponent<SpriteRenderer>().color = color;

        moveVector = new Vector3(-randomSpeed, 0);
        // возможно выделить в глобальную
        transform.localScale = new Vector3((randomSpeed / 10)+ 0.1f, (randomSpeed / 10) + 0.1f);
        transform.Translate(new Vector3(0, 0, 10 / randomSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( moveVector * Time.deltaTime);
        if (transform.position.x < -13) 
        { 
            Destroy(gameObject);
        }
    }
}
