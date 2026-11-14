using UnityEngine;
using UnityEngine.InputSystem;

public class FrogHop : MonoBehaviour
{
    public float hopForce = 12f;
    public float moveSpeed = 5f;
    public int maxHops = 2;

    public Transform feetCheck;
    public float feetCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool isGrounded;
    public int hopsUsed;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        isGrounded = Physics2D.OverlapCircle(feetCheck.position, feetCheckRadius, groundLayer);

        // Reset only when standing AND not still rising, or the frame right after a hop would reset it
        if (isGrounded && rb.linearVelocity.y <= 0.1f)
        {
            hopsUsed = 0;
        }

        float horizontal = 0f;
        if (kb.leftArrowKey.isPressed) horizontal -= 1f;
        if (kb.rightArrowKey.isPressed) horizontal += 1f;
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        if (kb.spaceKey.wasPressedThisFrame && hopsUsed < maxHops)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, hopForce);
            hopsUsed++;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (feetCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetCheck.position, feetCheckRadius);
    }
}