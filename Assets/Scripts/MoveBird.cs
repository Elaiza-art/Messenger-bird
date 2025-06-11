using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class MoveBird : MonoBehaviour
{
    [SerializeField]
    private AudioSource hitSound;
    [SerializeField]
    private AudioSource pointSound;

    [SerializeField]
    private GameObject spawnBulletPoint;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private int lifeCounter = 0;
    [SerializeField]
    private int bulletCount = 3;
    Vector3 moveVector;
    [SerializeField]
    private UnityEngine.UI.Image[] hearts;
    [SerializeField]
    private TextMeshProUGUI bulletCounterText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletCounterText.text = bulletCount.ToString();
        moveVector = new Vector3(0, speed);
        lifeCounter = hearts.Length;
    }

    public void fire()
    {
        if (bulletCount == 0) return;
        GameObject bulletObject = Instantiate(bullet); 
        bulletObject.transform.position = spawnBulletPoint.transform.position;
        bulletCount--;
        bulletCounterText.text = bulletCount.ToString();
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
        if(transform.position.y < - 7) { 
            SceneManager.LoadScene("GameOver");
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag.Equals("angryBird"))
        {
            hitSound.Play();
            updateLife(collision.gameObject.GetComponent<AngryBirrd>().damage);
            gameObject.GetComponent<ParticleSystem>().Play();
        }
        else if (collision.gameObject.tag.Equals("itemEgg"))
        {
            pointSound.Play();
            bulletCount += collision.gameObject.GetComponent<ItemsEggs>().quantity;
            bulletCounterText.text = bulletCount.ToString();
        }
    }
}
