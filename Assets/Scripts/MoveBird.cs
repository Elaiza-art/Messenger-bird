using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    Vector3 moveVector;
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
            hearts[i].enabled = i < lifeCounter;}
        if (lifeCounter == 0) 
        {
            GetComponent<Animation>().Play("dead_bird");
        }
    }
    // Update is called once per frame
    public void Update()
    {
        if(transform.position.y < -9.5f) { 
            SceneManager.LoadScene("GameOver");
        } 
    }
}
