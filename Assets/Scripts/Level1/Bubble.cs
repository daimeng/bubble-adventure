using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float size = 0.1f;
    private float maxsize = 1;
    private CircleCollider2D collider;

    void OnTriggerEnter2D(Collider2D c)
    {
        c.TryGetComponent(out Movement m);
        if (m != null)
        {
            m.bubble = this;
            m.launching = false;
            var rb = c.attachedRigidbody;
            rb.gravityScale = 0;
            rb.linearVelocity /= 2;
            var d = transform.position - c.transform.position;
            rb.MovePosition((transform.position + c.transform.position) / 2);
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        c.TryGetComponent(out Movement m);
        if (m != null)
        {
            var rb = c.attachedRigidbody;
            var d = transform.position - rb.transform.position;
            if (!m.launching)
            {
                rb.AddForce(d, ForceMode2D.Impulse);
                rb.linearVelocity *= 0.9f;
            }
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        c.TryGetComponent(out Movement m);
        if (m != null)
        {
            m.bubble = null;
            c.attachedRigidbody.gravityScale = 0.5f;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.position = new Vector3(transform.position.x, transform.position.y + 0.01f);
    }
}
