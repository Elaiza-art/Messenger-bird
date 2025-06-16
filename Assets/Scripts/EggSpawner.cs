using UnityEngine;
using System.Collections;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnXOffset = 1f; // ������ �� ���� ������

    private float spawnXRange;
    private Coroutine spawningCoroutine;

    void Start()
    {
        if (eggPrefab == null)
        {
            Debug.LogError("Egg prefab is not assigned!", this);
            return;
        }

        CalculateScreenBounds();
        spawningCoroutine = StartCoroutine(SpawnEggs());
    }

    IEnumerator SpawnEggs()
    {
        // ��������� �������� ����� ������ �������
        yield return new WaitForSeconds(1f);

        while (true)
        {
            if (ScoreManager.Instance != null && ScoreManager.Instance.isGameActive)
            {
                SpawnSingleEgg();
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnSingleEgg()
    {
        if (Camera.main == null) return;

        float topY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector2 spawnPos = new Vector2(randomX, topY);

        Instantiate(eggPrefab, spawnPos, Quaternion.identity);
    }

    public void StopSpawning()
    {
        if (spawningCoroutine != null)
        {
            StopCoroutine(spawningCoroutine);
            spawningCoroutine = null;
        }
    }
    private void CalculateScreenBounds()
    {
        if (Camera.main == null) return;
        float screenAspect = Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;
        float screenWidth = screenHeight * screenAspect;

        spawnXRange = screenWidth - spawnXOffset;
    }

    void OnDestroy()
    {
        StopSpawning();
    }
}
