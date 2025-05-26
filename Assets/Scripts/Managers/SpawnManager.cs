using UnityEngine;
using System.Collections; 

public class SpawnManager : MonoBehaviour
{
    public GameObject rainDrops;
    public GameObject enemyLeg; 

    [SerializeField] private int rainDropsNumber = 1;
    //private float spawnRange = 6f;
    private float spawnCooldown = 1.0f;
    private float timeSinceLastSpawn = 0f;

    [SerializeField] private float rainDropInterval = 0.2f;

    [SerializeField] private float rectWidth = 25f;
    [SerializeField] private float rectHeight = 20f;
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

            // Debug.Log("Instantiated raindrop " + i);
            // Debug.Log("Next raindrop being delayed");
            yield return new WaitForSeconds(rainDropInterval);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float yOffset = 15f;

        float x = transform.position.x + Random.Range(-rectWidth / 2f, rectWidth / 2f);
        float z = transform.position.z + Random.Range(-rectHeight / 2f, rectHeight / 2f);

        return new Vector3(x, transform.position.y + yOffset, z);
    }
}
