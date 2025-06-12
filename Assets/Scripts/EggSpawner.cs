using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public float spawnRate = 1f;
    private float spawnXRange; // ������� ��������� ����, ����� ��������� �������������

    void Start()
    {
        // ��������� ������� ������
        CalculateScreenBounds();

        InvokeRepeating("SpawnEgg", 1f, spawnRate);
    }

    // ����� ��� ������� ������ ������
    void CalculateScreenBounds()
    {
        // ������������ ������ ������ � ������� �����������
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // ������������� �������� ������ � �������� 1 ������� �� ����
        spawnXRange = screenWidth - 1f;
    }

    void SpawnEgg()
    {
        // ������� ������� ������
        float topY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;

        // ��������� ������� �� X � �������� ������
        float randomX = Random.Range(-spawnXRange, spawnXRange);

        Vector2 spawnPos = new Vector2(randomX, topY);
        Instantiate(eggPrefab, spawnPos, Quaternion.identity);
    }
}