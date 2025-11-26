using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public float spawnX = 1f;      // Right side of the screen
    public float minY = -4f;
    public float maxY = 4f;
    public float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnAsteroid();
            timer = spawnInterval;
        }
    }

    void SpawnAsteroid()
    {
        if (asteroidPrefabs.Length == 0) return;

        GameObject chosenPrefab = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, randomY, 0f);

        Instantiate(chosenPrefab, spawnPos, Quaternion.identity);
    }
}
