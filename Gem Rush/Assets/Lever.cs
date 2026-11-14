using UnityEngine;

// Goes on each Lever (collider set to Is Trigger).
public class Lever : MonoBehaviour
{
    [SerializeField] int leverId;
    [SerializeField] Gate gate;

    private bool pulled = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pulled || !other.CompareTag("Miner")) return;
        pulled = true;

        GetComponent<SpriteRenderer>().color = Color.green;
        gate.PullLever(leverId);
    }
}
