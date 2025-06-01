using UnityEngine;
using UnityEngine.EventSystems;

public class BirdParentMove : MonoBehaviour
{
    public int moveDirection = 0;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private Vector3 moveVector;
    void Start()
    {
        moveVector = new Vector3(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 3.71 && moveDirection == 1)
        {
            transform.Translate(moveVector * Time.deltaTime);
        }
        else if (transform.position.y > -3.58 && moveDirection == -1)
        {
            transform.Translate(-moveVector * Time.deltaTime);
        }
    }
}
