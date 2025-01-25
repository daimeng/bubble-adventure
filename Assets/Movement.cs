using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of horizontal movement
    public float jumpForce = 10f; // Force applied when jumping
    public LayerMask groundLayer; // LayerMask to detect ground
    public Transform groundCheck; // Empty GameObject to check if the player is grounded
    public float groundCheckRadius = 0.5f; // Radius for ground check

    public Bubble bubble = null;

    private Rigidbody2D rb;
    private bool isGrounded;

    // private PlayerInputManager inputs;

    void Start()
    {
        // inputs = new PlayerInputManager();
        rb = GetComponent<Rigidbody2D>();
    }

    // void OnCollisionEnter2D(Collision2D c)
    // {
    //     if (c.gameObject.layer == 6)
    //     {
    //         isGrounded = true;
    //     }
    // }

    void Update()
    {
        if (bubble != null)
        {
            var d = (bubble.transform.position - transform.position) / 2;
            var nextpos = transform.position + d;
            if (d.sqrMagnitude < 0.1)
            {
                rb.MovePosition(bubble.transform.position);
                bubble = null;
            }
            else
            {
                rb.MovePosition(nextpos);
            }

            return;
        }

        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        // Handle horizontal movement
        float moveInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump")) // Spacebar
        {
            Debug.Log("Jump");
            isGrounded = false;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Optional: Draw the ground check radius in the editor for debugging
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
        }
    }
}
