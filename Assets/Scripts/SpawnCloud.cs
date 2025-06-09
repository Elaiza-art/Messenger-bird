using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spownPoint;
    [SerializeField]
    private GameObject cloud;
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private float spawnInterval = 1.0f;
    [SerializeField]
    private float spawnBirdInterval = 2.0f;

    void Start()
    {
        Invoke("SpownClud", spawnInterval);
        Invoke("SpownBird", spawnBirdInterval);
    }

    private void SpownClud()
    {
        int index = UnityEngine.Random.Range(0, 4);
        GameObject cl = Instantiate(cloud);
        Vector3 position = spownPoint[index].transform.position;
        cl.transform.position = position;
        Invoke("SpownClud", spawnInterval);
    }

    private void SpownBird()
    {
        int index = UnityEngine.Random.Range(0, 4);
        GameObject bi = Instantiate(bird);
        Vector3 position = spownPoint[index].transform.position;
        bi.transform.position = position;
        Invoke("SpownBird", spawnBirdInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
