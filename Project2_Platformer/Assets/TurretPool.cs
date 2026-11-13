using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPool : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int poolSize = 5;
    
    [Header("Firing Settings")]
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float projectileSpeed = 5f;
    public Vector2 fireDirection = Vector2.left;

    [Header("Warning Settings")]
    [SerializeField] private float warningDuration = 0.5f;
    [SerializeField] private Color warningColor = Color.red;

    [Header("Movement Settings")]
    [SerializeField] private float teleportInterval = 6f; // How often the turret jumps to a new spot

    private List<GameObject> pool;
    private int currentProjectileIndex = 0; 
    
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false); 
            pool.Add(obj);
        }

        // Start both the firing loop and the teleporting loop
        StartCoroutine(FireSequence());
        StartCoroutine(TeleportSequence());
    }

    IEnumerator FireSequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate - warningDuration);

            if (spriteRenderer != null)
            {
                spriteRenderer.color = warningColor;
            }

            yield return new WaitForSeconds(warningDuration);

            FireProjectile();

            if (spriteRenderer != null)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }

    IEnumerator TeleportSequence()
    {
        while (true)
        {
            // Wait for the specified interval before moving
            yield return new WaitForSeconds(teleportInterval);

            // Teleport to a new random position inside the arena
            float randomX = Random.Range(-7f, 7f);
            float randomY = Random.Range(-4f, 4f);
            transform.position = new Vector3(randomX, randomY, 0);

            // Pick a new random firing direction to keep it unpredictable
            float randomDirX = Random.Range(-1f, 1f);
            float randomDirY = Random.Range(-1f, 1f);
            
            // Prevent a rare case where the vector is exactly (0,0)
            if (randomDirX == 0 && randomDirY == 0) randomDirX = 1f;

            fireDirection = new Vector2(randomDirX, randomDirY).normalized;
        }
    }

    void FireProjectile()
    {
        GameObject obj = pool[currentProjectileIndex];
        
        // Move to turret before activating
        obj.transform.position = transform.position;
        
        // CLEAR THE TRAIL: Prevents the giant beam bug
        TrailRenderer trail = obj.GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trail.Clear();
        }

        obj.SetActive(true);
        
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = fireDirection * projectileSpeed; 
        }

        currentProjectileIndex++;
        if (currentProjectileIndex >= pool.Count)
        {
            currentProjectileIndex = 0;
        }
    }
}
