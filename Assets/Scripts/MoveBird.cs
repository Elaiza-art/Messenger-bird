using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;




public class MoveBird : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnBulletPoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private int lifeCounter = 0;
    private Vector3 moveVector;
    public int moveDirection = 0;
    [SerializeField]
    private UnityEngine.UI.Image[] hearts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveVector = new Vector3(0, speed);
        lifeCounter = hearts.Length;
    }

    public void fire()
    {
        GameObject bulletObject = Instantiate(bullet); 
        bulletObject.transform.position = spawnBulletPoint.transform.position;
    } 
    public void updateLife(int life)
    {
        lifeCounter += life;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lifeCounter;

        }
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
