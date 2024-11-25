using UnityEngine;

// made with the help of github copilot
public class Enemy : MonoBehaviour
{
    public GameObject objectToSpawn; // Reference to the object to be spawned
    public Transform player; // Reference to the player
    public float spawnInterval = 2f; // Time interval between spawns
    public float objectSpeed = 5f; // Speed of the spawned objects

    public Vector3 quadCenter; // Center of the quad area
    public float quadWidth = 10f; // Width of the quad area
    public float quadHeight = 10f; // Height of the quad area

    private float nextSpawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        // Generate a random position within the quad area
        float randomX = Random.Range(quadCenter.x - quadWidth / 2, quadCenter.x + quadWidth / 2);
        float randomZ = Random.Range(quadCenter.z - quadHeight / 2, quadCenter.z + quadHeight / 2);
        Vector3 spawnPosition = new Vector3(randomX, quadCenter.y, randomZ);

        // Calculate the direction towards the player
        Vector3 directionToPlayer = (player.position - spawnPosition).normalized;

        // Calculate the rotation to face the player
        Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

        // Instantiate the object with the calculated rotation
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, lookRotation);


        // Apply the direction to the spawned object
        spawnedObject.GetComponent<Rigidbody>().linearVelocity = directionToPlayer * objectSpeed;
    }
}
