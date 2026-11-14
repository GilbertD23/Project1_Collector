using UnityEngine;

// Goes on the Coin prefab (collider set to Is Trigger).
public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] AudioClip collectClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        GameSession.Score += value;
        other.GetComponent<PlayerController>().PlayCollectEffect();
        if (collectClip != null) AudioSource.PlayClipAtPoint(collectClip, transform.position);
        Destroy(gameObject);
    }
}
