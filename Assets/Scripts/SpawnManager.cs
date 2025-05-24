using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject rainDrops;
    [SerializeField]
    private int rainDropsNumber = 1;
    private float spawnRange = 6.0f;
    private float spawnCooldown = 1.0f;
    private float timeSinceLastSpawn = 0f;

    private void Start()
    {
        SpawnRainDropWave(rainDropsNumber);
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        //Debug.Log($"Time since last spawn: {timeSinceLastSpawn}");

        // Only spawn if there are no raindrops and cooldown has passed
        if (GameObject.FindGameObjectsWithTag("Raindrop").Length == 0 && timeSinceLastSpawn >= spawnCooldown)
        {
            SpawnRainDropWave(rainDropsNumber);
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnRainDropWave(int rainToSpawn)
    {
        for (int i = 0; i < rainToSpawn; i++)
        {
            Instantiate(rainDrops, GenerateSpawnPosition(), rainDrops.transform.rotation);
            //Debug.Log("Instantiated raindrop " + i);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(randomX, 5, randomZ);
    }
}
