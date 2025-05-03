using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public float spawnRate = 1f;
    public float spawnXRange = 5f; // Диапазон по X для спавна

    void Start()
    {
        InvokeRepeating("SpawnEgg", 1f, spawnRate);
    }

    void SpawnEgg()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnXRange, spawnXRange), Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y);
        Instantiate(eggPrefab, spawnPos, Quaternion.identity);
    }
}