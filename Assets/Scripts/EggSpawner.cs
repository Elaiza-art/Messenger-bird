using UnityEngine;
using System.Collections;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public float spawnRate = 1f;
    private bool isSpawning = true; 
    private float spawnXRange; 
    private Coroutine spawningCoroutine;

    void Start()
    {
        // Вычисляем границы экрана
        CalculateScreenBounds();

        InvokeRepeating("SpawnEgg", 1f, spawnRate);
        StartCoroutine(SpawnEggs());
        spawningCoroutine = StartCoroutine(SpawnEggs());

    }
    IEnumerator SpawnEggs()
    {
        while (true)
        {
            
            if (ScoreManager.Instance != null && ScoreManager.Instance.isGameActive)
            {
                Vector2 spawnPos = new Vector2(
                    Random.Range(-8f, 8f),
                    Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y);

                Instantiate(eggPrefab, spawnPos, Quaternion.identity);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void StopSpawning()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
            spawningCoroutine = null;
        }
    }



    void CalculateScreenBounds()
    {
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        spawnXRange = screenWidth - 1f;
    }

    void SpawnEgg()
    {
        
        float topY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;

       
        float randomX = Random.Range(-spawnXRange, spawnXRange);

        Vector2 spawnPos = new Vector2(randomX, topY);
        Instantiate(eggPrefab, spawnPos, Quaternion.identity);
    }
    

  
}
