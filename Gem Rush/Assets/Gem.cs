using UnityEngine;

// Goes on the Gem prefab (collider set to Is Trigger).
public class Gem : MonoBehaviour
{
    [SerializeField] int worth = 1;
    [SerializeField] AudioClip pickupClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Miner")) return;

        RunState.Gems += worth;
        other.GetComponent<MinerController>().PlayPickupEffect();
        if (pickupClip != null) AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        Destroy(gameObject);
    }
}
