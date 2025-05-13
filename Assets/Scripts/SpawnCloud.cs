using UnityEngine;

public class SpawnCloud : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spownPoint;
    [SerializeField]
    private GameObject cloud;
    [SerializeField]
    private float spawnInterval = 1.0f;

    void Start()
    {
        Invoke("SpownClud", spawnInterval);
    }

    private void SpownClud()
    {
        int index = UnityEngine.Random.Range(0, 4);
        GameObject cl = Instantiate(cloud);
        Vector3 position = spownPoint[index].transform.position;
        cl.transform.position = position;
        Invoke("SpownClud", spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
