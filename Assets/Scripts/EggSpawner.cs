using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public float spawnRate = 1f;
    private float spawnXRange; // Убираем публичное поле, будем вычислять автоматически

    void Start()
    {
        // Вычисляем границы экрана
        CalculateScreenBounds();

        InvokeRepeating("SpawnEgg", 1f, spawnRate);
    }

    // Метод для расчета границ спавна
    void CalculateScreenBounds()
    {
        // Рассчитываем ширину экрана в мировых координатах
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // Устанавливаем диапазон спавна с отступом 1 единицу от края
        spawnXRange = screenWidth - 1f;
    }

    void SpawnEgg()
    {
        // Верхняя граница экрана
        float topY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;

        // Случайная позиция по X в пределах экрана
        float randomX = Random.Range(-spawnXRange, spawnXRange);

        Vector2 spawnPos = new Vector2(randomX, topY);
        Instantiate(eggPrefab, spawnPos, Quaternion.identity);
    }
}