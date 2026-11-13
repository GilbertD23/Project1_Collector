using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Rubric Req 4: Scriptable Object Data
    [SerializeField] private CollectibleData coinData;
    
    // Rubric Req 3 & 5: Audio and Particles
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private ParticleSystem sparkPrefab;

    private PuzzleController puzzleController;
    
    // Prevents the multi-collision bug
    private bool isCollected = false;

    private void Start()
    {
        // Using FindAnyObjectByType to avoid the obsolete warning
        puzzleController = FindAnyObjectByType<PuzzleController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only run if the player touches it AND it hasn't been collected yet
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            
            // INSTANTLY turn off the hitbox so it physically cannot be touched twice
            GetComponent<Collider2D>().enabled = false;

            // Play sound via your Singleton AudioManager
            if (AudioManager.Instance != null && coinSound != null)
            {
                AudioManager.Instance.PlaySFX(coinSound);
            }

            // Spawn particle effects (Req 5)
            if (sparkPrefab != null)
            {
                Instantiate(sparkPrefab, transform.position, Quaternion.identity);
            }

            // Update the puzzle state/score
            if (puzzleController != null && coinData != null)
            {
                puzzleController.CollectCoin(coinData.coinValue);
            }

            // Destroy this coin object
            Destroy(gameObject);
        }
    }
}