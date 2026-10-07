using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private InputActionReference moveAction; 
    
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
