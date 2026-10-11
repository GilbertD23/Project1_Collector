using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject turretPrefab;
    public int maxTurrets = 4;
    
    private int currentTurretCount = 0;

    public void SpawnNewTurret()
    {
        // Stop spawning if we reached the maximum allowed turrets
        if (currentTurretCount >= maxTurrets)
        {
            return; 
        }

        float randomX = Random.Range(-7f, 7f);
        float randomY = Random.Range(-4f, 4f);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        GameObject newTurret = Instantiate(turretPrefab, spawnPosition, Quaternion.identity);
        currentTurretCount++;

        TurretPool turretScript = newTurret.GetComponent<TurretPool>();
        if (turretScript != null)
        {
            float randomDirX = Random.Range(-1f, 1f);
            float randomDirY = Random.Range(-1f, 1f);
            turretScript.fireDirection = new Vector2(randomDirX, randomDirY).normalized;
        }
    }
}
