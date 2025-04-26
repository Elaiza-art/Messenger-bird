using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float speed = 6.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0));
        if (transform.position.x < -13) 
        { 
            Destroy(gameObject);
        }
    }
}
