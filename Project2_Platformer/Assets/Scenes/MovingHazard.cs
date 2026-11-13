using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingHazard : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distance = 2f;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Moves the enemy up and down automatically
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector2(transform.position.x, newY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player touches the enemy, restart the level (Game Over)
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}