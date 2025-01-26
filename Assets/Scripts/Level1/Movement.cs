using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject restartUI;
    public Slider hpSlider;
    [SerializeField] private float MAXHP = 3f;
    private float _hp;

    private LayerMask defaultLayer;

    // Drag and Launch
    private Vector2 mousePos = Vector2.zero;
    private bool isDragging = false;

    public Bubble bubble = null;

    public bool controlled = true;

    public float maxDragDist = 3f;
    public float launchForceMult = 0.05f;

    public bool launching = false;

    public LayerMask groundLayer; // LayerMask to detect ground
    public Transform DrawLine;
    private SpriteRenderer drawline;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        _hp = MAXHP;
        defaultLayer = LayerMask.GetMask("Default");
        drawline = DrawLine.GetComponent<SpriteRenderer>();
        drawline.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        hpSlider.maxValue = MAXHP;
        hpSlider.value = _hp;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.layer == 6)
        {
            isGrounded = true;
            launching = false;
            if (c.gameObject.CompareTag("Win"))
            {
                //Debug.Log("Win!");
                SceneManager.LoadScene("dialogue1");
            }
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

        if (bubble == null)
        {
            _hp -= Time.deltaTime;
        }
        else
        {
            _hp += Time.deltaTime;
        }

        if (_hp < 0)
        {
            Debug.Log("restart");
            restartUI.SetActive(true);
            Destroy(gameObject);
        }
        else if (_hp > MAXHP)
        {
            _hp = MAXHP;
        }
        hpSlider.value = _hp;
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
                isDragging = true;
                // rb.isKinematic = true; // Disable physics while dragging
            }
        }

        if (isDragging)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dragDirection = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y);
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

            Vector2 dragDirection = new Vector2(transform.position.x - mousePos.x, transform.position.y - mousePos.y);
            dragDirection = Vector2.ClampMagnitude(dragDirection, maxDragDist);
            Debug.Log($"DRAG END: {mousePos}");

            var f = dragDirection;
            var mod = (float)Math.Log(f.sqrMagnitude) / 2;
            launching = true;
            isGrounded = false;
            rb.AddForce(mod * launchForceMult * f.normalized, ForceMode2D.Impulse);
        }
    }
}
