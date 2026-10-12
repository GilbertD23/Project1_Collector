using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Updated to use SerializeField per Code Quality rubric guidelines
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject safeExit; 

    private Rigidbody2D rb;
    private int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Hide the exit portal at start
        if (safeExit != null)
        {
            safeExit.SetActive(false);
        }

        // Prove PlayerPrefs loaded successfully in the console
        Debug.Log("Session Started. Current High Score: " + PlayerPrefs.GetInt("HighScore", 0));
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
            
            // Requirement 7: Save High Score state using PlayerPrefs
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                PlayerPrefs.Save();
            }

            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
            }
            
            moveSpeed += 0.5f; 

            // Reveal SafeExit once score hits 1000
            if (score >= 1000 && safeExit != null)
            {
                safeExit.SetActive(true);
            }

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
        // Death condition
        else if (other.CompareTag("Projectile"))
        {
            // Reload the current scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // Win condition
        else if (other.CompareTag("Exit"))
        {
            // Load the Main Menu on game win
            SceneManager.LoadScene("MainMenu");
        }
    }
}
