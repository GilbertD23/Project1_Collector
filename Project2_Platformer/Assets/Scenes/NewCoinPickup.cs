using UnityEngine;

public class NewCoinPickup : MonoBehaviour
{
    [SerializeField] private CollectibleData coinData;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private ParticleSystem sparkPrefab;

    private PuzzleController puzzleController;
    private bool isCollected = false;

    private void Start()
    {
        puzzleController = FindAnyObjectByType<PuzzleController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            GetComponent<Collider2D>().enabled = false;

            if (AudioManager.Instance != null && coinSound != null)
            {
                AudioManager.Instance.PlaySFX(coinSound);
            }

            if (sparkPrefab != null)
            {
                Instantiate(sparkPrefab, transform.position, Quaternion.identity);
            }

            if (puzzleController != null && coinData != null)
            {
                puzzleController.CollectCoin(coinData.coinValue);
            }

            Destroy(gameObject);
        }
    }
}