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
    void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if the object we bumped into has the tag "Coin"
        if (other.gameObject.CompareTag("Coin"))
        {
            score++; // Increase the score by 1
            scoreText.text = "Score: " + score; // Update the screen
            Destroy(other.gameObject); // Destroy the collected coin
        }
    }
}
