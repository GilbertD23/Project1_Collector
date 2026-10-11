using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputActionReference moveAction; 
    
    // Moved inside the class, plus added an integer to track the actual number
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ensure the text starts at 0 when the game begins
        scoreText.text = "Score: " + score; 
    }

    void Update()
    {
        // Safe hardware check before reading input
        if (Keyboard.current == null && Gamepad.current == null) return;

        // Read the Vector2 value from the Input Actions Asset
        moveInput = moveAction.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Apply velocity directly to the Rigidbody
        rb.linearVelocity = moveInput * moveSpeed;
    }

    void OnEnable()
    {
        moveAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
    }

    // This handles the physics collision for collecting the item
    // This handles the physics collision for collecting the item
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hazard"))
            {
                // Reloads the current scene immediately
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }

            // Checks if the object we bumped into has the tag "Coin"
            if (other.CompareTag("Coin"))
            {
                // Add points to the score
                score += 10;
                scoreText.text = "Score: " + score;

                // Pick a random X and Y inside your specific walls.
                float randomX = UnityEngine.Random.Range(-7f, 7f);
                float randomY = UnityEngine.Random.Range(-4f, 4f);

                // Teleport the coin to the new spot instantly!
                other.transform.position = new UnityEngine.Vector3(randomX, randomY, 0);
            }

            // Checks if we reached the exit (Requirement 7 & Scene Management)
            if (other.CompareTag("Goal"))
            {
                UnityEngine.PlayerPrefs.SetInt("SavedScore", score);
                UnityEngine.PlayerPrefs.Save();
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
            
        }
    }
}
