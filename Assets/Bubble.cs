using UnityEngine;

public class Bubble : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        c.TryGetComponent(out Movement m);
        if (m != null)
        {
            m.bubble = this;
            c.attachedRigidbody.gravityScale = 0;
            c.attachedRigidbody.linearVelocity = Vector2.zero;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
