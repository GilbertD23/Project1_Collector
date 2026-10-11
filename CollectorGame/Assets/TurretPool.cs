using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPool : MonoBehaviour
{
    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolSize = 5;
    
    [Header("Firing Settings")]
    public float fireRate = 2f;
    public float projectileSpeed = 5f;
    public Vector2 fireDirection = Vector2.left;

    [Header("Warning Settings")]
    public float warningDuration = 0.5f;
    public Color warningColor = Color.red;

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

        StartCoroutine(FireSequence());
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

    void FireProjectile()
    {
        GameObject obj = pool[currentProjectileIndex];
        
        obj.transform.position = transform.position;
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
