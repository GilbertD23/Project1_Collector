using UnityEngine;
using UnityEngine.InputSystem;

// Goes on Miner. Moves and jumps with the Input System (PlayerInput, Send Messages).
[RequireComponent(typeof(Rigidbody2D))]
public class MinerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float leapPower = 9f;
    [SerializeField] Transform feetProbe;
    [SerializeField] float probeRadius = 0.2f;
    [SerializeField] LayerMask floorMask;
    [SerializeField] Animator walkAnimator;
    [SerializeField] ParticleSystem pickupSparks;
    [SerializeField] float abyssY = -8f;

    Rigidbody2D rb;
    Vector2 walkInput;
    Vector3 startSpot;
    bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startSpot = transform.position;
    }

    public void OnWalk(InputValue value)
    {
        walkInput = value.Get<Vector2>();
    }

    public void OnLeap(InputValue value)
    {
        if (value.isPressed && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, leapPower);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetProbe.position, probeRadius, floorMask);
        if (walkAnimator != null) walkAnimator.SetBool("IsWalking", Mathf.Abs(walkInput.x) > 0.1f);
        if (transform.position.y < abyssY) ReturnToStart();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(walkInput.x * walkSpeed, rb.linearVelocity.y);
    }

    public void PlayPickupEffect()
    {
        if (pickupSparks != null) pickupSparks.Play();
    }

    public void ReturnToStart()
    {
        transform.position = startSpot;
        rb.linearVelocity = Vector2.zero;
    }
}
