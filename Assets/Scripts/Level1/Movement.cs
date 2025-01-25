using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private LayerMask defaultLayer;

    // Drag and Launch
    private Vector3 launchStart;
    private Vector2 dragStart;
    private Vector2 mousePos = Vector2.zero;
    private bool isDragging = false;

    public Bubble bubble = null;

    public bool controlled = true;

    public float maxDragDist = 3f;
    public float launchForceMult = 0.1f;

    public LayerMask groundLayer; // LayerMask to detect ground
    public Transform groundCheck; // Empty GameObject to check if the player is grounded
    public float groundCheckRadius = 0.5f; // Radius for ground check
    public Transform DrawLine;
    private SpriteRenderer drawline;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        defaultLayer = LayerMask.GetMask("Default");
        drawline = DrawLine.GetComponent<SpriteRenderer>();
        drawline.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void FixedUpdate()
    {
        // Apply some friction on Ground to stop sliding
        if (isGrounded)
        {
            if (Math.Abs(rb.linearVelocityX) < 0.5)
            {
                rb.linearVelocityX = 0;
            }
            else
            {
                rb.linearVelocityX *= 0.8f;
            }
        }

        if (bubble == null) return;

        // If in bubble, suck to center
        var d = (bubble.transform.position - transform.position) / 2;
        var clamped = Math.Min(d.magnitude, 0.1f);
        var nextpos = transform.position + d.normalized * clamped;
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

        // Drag Controls
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            // Check if the mouse is over the object
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 1, defaultLayer);
            Debug.Log($"DRAG START: {mousePos}, {hit.collider}, {gameObject}");

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                drawline.enabled = true;
                dragStart = mousePos;
                isDragging = true;
                // rb.isKinematic = true; // Disable physics while dragging
            }
        }

        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragDirection = dragStart - mousePos;
            dragDirection = Vector2.ClampMagnitude(dragDirection, maxDragDist);
            // Convert the direction to a Quaternion rotation
            float angle = Mathf.Atan2(dragDirection.y, dragDirection.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);

            // Apply the rotation to the object
            DrawLine.transform.SetPositionAndRotation(transform.position, rotation);
            DrawLine.localScale = new Vector3(dragDirection.magnitude, 0.1f, 1);

        }

        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            if (!isDragging) return;

            isDragging = false;
            drawline.enabled = false;

            Vector2 dragDirection = dragStart - mousePos;
            dragDirection = Vector2.ClampMagnitude(dragDirection, maxDragDist);
            Debug.Log($"DRAG END: {mousePos}");

            var f = dragDirection;
            var mod = (float)Math.Log(f.sqrMagnitude) / 2;
            rb.AddForce(f.normalized * mod * launchForceMult, ForceMode2D.Impulse);
            rb.gravityScale = 0.5f;
            isGrounded = false;
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
