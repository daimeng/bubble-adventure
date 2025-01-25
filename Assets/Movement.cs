using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    // Drag and Launch
    private Vector3 launchStart;
    private Vector2 dragStart;
    private bool isDragging = false;

    public float maxDragDist = 3f;
    public float launchForceMult = 10f;

    public float moveSpeed = 5f; // Speed of horizontal movement
    public float jumpForce = 10f; // Force applied when jumping
    public LayerMask groundLayer; // LayerMask to detect ground
    public Transform groundCheck; // Empty GameObject to check if the player is grounded
    public float groundCheckRadius = 0.5f; // Radius for ground check

    public Bubble bubble = null;

    public bool controlled = true;

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

    void FixedUpdate()
    {
        if (bubble == null) return;

        var d = (bubble.transform.position - transform.position) / 2;
        var nextpos = transform.position + d;
        if (d.sqrMagnitude < 0.1)
        {
            rb.MovePosition(bubble.transform.position);
            bubble = null;
            controlled = true;
        }
        else
        {
            rb.MovePosition(nextpos);
        }
    }

    void Update()
    {
        if (!controlled) return;

        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            // Check if the mouse is over the object
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            Debug.Log($"DRAG START: {mousePosition}, {hit.collider}, {gameObject}");

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                // rb.isKinematic = true; // Disable physics while dragging
                dragStart = mousePosition;
            }
        }

        if (isDragging)
        {

        }

        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            if (!isDragging) return;

            isDragging = false;

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragDirection = dragStart - mousePosition;
            dragDirection = Vector2.ClampMagnitude(dragDirection, maxDragDist);
            Debug.Log($"DRAG END: {mousePosition}");

            var f = dragDirection * launchForceMult;
            var mod = (float)Math.Log(f.sqrMagnitude) / 2;
            rb.AddForce(f * mod, ForceMode2D.Impulse);
            rb.gravityScale = 1;
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

        if (isDragging)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(dragStart, transform.position);
        }
    }
}
