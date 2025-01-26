using System;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float maxsize = 1.9f;
    private CircleCollider2D collider;

    private float phasex = 0.5f;
    private float vx = 0.0f;
    private float vy = 0.01f;

    void Awake()
    {
        vy += UnityEngine.Random.value / 100;
        var scale = 0.4f + UnityEngine.Random.value / 3;
        transform.localScale = new Vector3(scale, scale, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        c.TryGetComponent(out Bubble b);
        if (b != null)
        {
            if (transform.localScale.x > b.transform.localScale.x)
            {
                // merge smaller bubble into larger
                transform.position = new Vector3(
                    transform.position.x + (b.transform.position.x - transform.position.x) / 2,
                    transform.position.y + (b.transform.position.y - transform.position.y) / 2,
                    transform.position.z
                );

                transform.localScale = new Vector3(
                    b.transform.localScale.x / 2 + transform.localScale.x,
                    b.transform.localScale.y / 2 + transform.localScale.y,
                    transform.localScale.z
                );
                Destroy(b.gameObject);
            }
        }

        c.TryGetComponent(out Movement m);
        if (m != null)
        {
            if (c.transform.localScale.x + 0.05 > transform.localScale.x)
            {
                transform.position = transform.position - (c.transform.position - transform.position) / 4;
                return;
            }

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
            d.y -= collider.radius / 10;
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
        if (transform.localScale.x > maxsize)
        {
            if (UnityEngine.Random.value < 0.1)
            {
                Destroy(gameObject);
            }
        }

        var dvx = Math.Clamp(UnityEngine.Random.value - phasex, -0.1f, 0.1f);
        vx += dvx * 0.03f;
        phasex += dvx * 0.05f;

        var tx = transform.position.x + vx;
        transform.position = new Vector3(tx, transform.position.y + vy);

        transform.localScale = new Vector3(transform.localScale.x + 0.001f, transform.localScale.y + 0.001f, transform.localScale.z);
    }
}
