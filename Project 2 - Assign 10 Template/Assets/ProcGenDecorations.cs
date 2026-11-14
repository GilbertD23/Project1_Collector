using UnityEngine;

public class ProcGenDecorations : MonoBehaviour
{
    public GameObject decorationPrefab; // E.g., a background star or cloud
    
    [SerializeField] private int randomSeed = 42; // Exposed Inspector parameter
    [SerializeField] private int amountToSpawn = 10;

    void Start()
    {
        Random.InitState(randomSeed);

        for (int i = 0; i < amountToSpawn; i++)
        {
            // Spawns high up in the background so it doesn't block the player
            Vector3 spawnPos = new Vector3(Random.Range(-10f, 10f), Random.Range(2f, 6f), 5f);
            Instantiate(decorationPrefab, spawnPos, Quaternion.identity);
        }
    }
}
