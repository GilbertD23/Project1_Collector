using UnityEngine;

// Goes on the Enemy. Patrols left and right using numbers from its EnemyStats asset.
public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyStats stats;
    [SerializeField] float patrolDistance = 2f;

    private Vector3 startPosition;
    private float direction = 1f;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = stats.color;
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * direction * stats.moveSpeed * Time.deltaTime, Space.World);

        if (transform.position.x > startPosition.x + patrolDistance) direction = -1f;
        else if (transform.position.x < startPosition.x - patrolDistance) direction = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerController>().Respawn();
    }
}
