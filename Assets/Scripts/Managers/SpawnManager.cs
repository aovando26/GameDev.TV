using UnityEngine;
using System.Collections; 

public class SpawnManager : MonoBehaviour
{
    public GameObject rainDrops;
    public GameObject enemyLeg; 

    [SerializeField] private int rainDropsNumber = 1;
    private float spawnRange = 6f;
    private float spawnCooldown = 1.0f;
    private float timeSinceLastSpawn = 0f;

    [SerializeField] private float rainDropInterval = 0.2f;
    private void Start()
    {
        StartCoroutine(SpawnRainDropWave(rainDropsNumber));
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        //Debug.Log($"Time since last spawn: {timeSinceLastSpawn}");

        // Only spawn if there are no raindrops and cooldown has passed
        if (GameObject.FindGameObjectsWithTag("Raindrop").Length == 0 && timeSinceLastSpawn >= spawnCooldown)
        {
            StartCoroutine(SpawnRainDropWave(rainDropsNumber));
            timeSinceLastSpawn = 0f;
            rainDropsNumber += 2; 
        }
    }

    IEnumerator SpawnRainDropWave(int rainToSpawn)
    {
        for (int i = 0; i < rainToSpawn; i++)
        {
            Instantiate(rainDrops, GenerateSpawnPosition(), rainDrops.transform.rotation);

            //Debug.Log("Instantiated raindrop " + i);
            Debug.Log("Next raindrop being delayed");
            yield return new WaitForSeconds(rainDropInterval);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector2 randomXZ = Random.insideUnitCircle * spawnRange;
        float yOffset = 15f; // Higher Y position
        Vector3 spawnPosition = new Vector3(
            transform.position.x + randomXZ.x,
            transform.position.y + yOffset,
            transform.position.z + randomXZ.y
        );
        return spawnPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        float yOffset = 15f;
        Vector3 center = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);

        // Draw a wire sphere to represent the spawn area
        Gizmos.DrawWireSphere(center, spawnRange);
    }
}
