using System.Collections;
using UnityEngine;

public class Lvl_Generator : MonoBehaviour
{
    [Header("Prefabs to spawn")]
    public GameObject[] prefabs;   // Assign prefabs in Inspector
    public int bufferLevels = 2;

    [Header("Spawn Settings")]
    public float spawnInterval = 2f;   // Seconds between spawns
    public int spawnCount = 10;        // How many objects to spawn
    //public Vector2 zRange = new Vector2(-10f, 10f); // Range for Z-axis placement
    //public Vector2 xRange = new Vector2(-5f, 5f);   // Optional X-axis range
    public float xPosition = 0f;       // Fixed Y position

    private int spawned = 0;

    [Header("Movement Settings")]
    public Vector3 direction = Vector3.forward; // Default: move along Z axis
    public float speed = 5f;                    // Units per second
    public float kill = 30f;                   // Time after which spawned objects are destroyed
    void Update()
    {
        // Normalize direction to ensure consistent speed
       // Vector3 normalizedDirection = direction.normalized;

        // Move object in chosen direction at given speed

       // transform.Translate(normalizedDirection * speed * Time.deltaTime, Space.World);

    }


    void Start()
    {
        // Start spawning repeatedly
        InvokeRepeating(nameof(SpawnRandom), 0f, spawnInterval);

        //buffer levels
        for (int i = 0; i < bufferLevels; i++)
        {
            // Instantiate
            GameObject instanced = Instantiate(prefabs[i], this.transform.position - new Vector3(60*(i+1), 0f, 0f), Quaternion.identity, this.transform);

            Destroy(instanced, kill); // Destroy after 30 seconds
            
            StartCoroutine(MoveObject(instanced));
        }
        

    }

    void SpawnRandom()
    {
        if (spawned >= spawnCount)
        {
            CancelInvoke(nameof(SpawnRandom));
            return;
        }

        if (prefabs.Length == 0) return;

        // Pick a random prefab
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
        

        // Change position
        //float randomZ = Random.Range(zRange.x, zRange.y);
        //float randomX = Random.Range(xRange.x, xRange.y);
        Vector3 spawnPos = new Vector3(xPosition * spawned, 0, 0);

        // Instantiate
        GameObject instanced = Instantiate(prefab, spawnPos, Quaternion.identity, this.transform);
                
        Destroy(instanced,kill); // Destroy after 30 seconds

        StartCoroutine(MoveObject(instanced));
        spawned++;
    }

    IEnumerator MoveObject(GameObject obj)
    {
        while (obj != null)
        {
            // Move object in chosen direction at given speed
            obj.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            yield return null;
        }
    }
}

