using TMPro;
using UnityEngine;

public class MoveBird : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI lifeStatus;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    int lifeCounter = 3;
    private Vector3 moveVector;
    public int moveDirection = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveVector = new Vector3(0, speed);
        lifeStatus.text = lifeCounter.ToString();
    }
    public void updateLife(int life)
    {
        lifeCounter += life;
        lifeStatus.text = lifeCounter.ToString();
    }// Update is called once per frame
    void Update()
    {
        if (transform.position.y < 3.71 && moveDirection == 1)
        {
            transform.Translate(moveVector * Time.deltaTime);
        }
        else if (transform.position.y > -3.58 && moveDirection == -1)
        {
            transform.Translate(- moveVector * Time.deltaTime);
        }
    }
}
