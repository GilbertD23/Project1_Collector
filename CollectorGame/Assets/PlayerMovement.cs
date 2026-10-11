using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement; // Added for restarting the level

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public InputActionReference moveAction;
    public TMP_Text scoreText;

    private Rigidbody2D rb;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        rb.linearVelocity = moveInput * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score += 50;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
            
            moveSpeed += 0.5f; 

            if (score % 150 == 0)
            {
                TurretSpawner spawner = Object.FindFirstObjectByType<TurretSpawner>();
                if (spawner != null)
                {
                    spawner.SpawnNewTurret();
                }
            }

            float randomX = Random.Range(-7f, 7f);
            float randomY = Random.Range(-4f, 4f);
            other.transform.position = new Vector3(randomX, randomY, 0);
        }
        // NEW: Death condition
        else if (other.CompareTag("Projectile"))
        {
            // Reload the current scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
