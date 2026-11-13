using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnDistance = 20f;
    
    [Tooltip("The X position where procedural generation should begin")]
    [SerializeField] private float startSpawnX = 25f; 
    
    [Tooltip("The locked Y position for the platforms so they don't block coins")]
    [SerializeField] private float lockedYPosition = -2f; 
    
    private float lastSpawnPositionX;
    private float platformWidth = 10f; 

    private void Start()
    {
        // Start generating platforms ONLY after the hand-built level ends
        lastSpawnPositionX = startSpawnX;
    }

    private void Update()
    {
        if (player.position.x + spawnDistance > lastSpawnPositionX)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        // Generates a random horizontal gap (pit) between platforms
        float randomGap = Random.Range(2f, 5f);
        
        // Calculates the new X position, but perfectly locks the Y position
        Vector2 spawnPosition = new Vector2(lastSpawnPositionX + platformWidth + randomGap, lockedYPosition);
        
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        
        // Updates the tracking variable for the next spawn
        lastSpawnPositionX += (platformWidth + randomGap);
    }
}