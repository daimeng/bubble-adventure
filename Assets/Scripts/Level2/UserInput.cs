using System;
using UnityEngine;

namespace Level2
{
    public class UserInput : UnityEngine.MonoBehaviour
    {
        private Rigidbody2D _rb;
        private MicDetector _mic;
        [SerializeField] private float verticalForce;
        [SerializeField] private float horizontalForce;
        [SerializeField] private SpriteRenderer playerSprite;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _mic = GetComponent<MicDetector>();
        }

        private void Update()
        {
            if (Math.Abs(_rb.linearVelocityX) >= 0.01f)
                playerSprite.flipX = (_rb.linearVelocityX <= 0);
            var dir = new Vector2(0, 0);
            if (Input.GetKey(KeyCode.A))
                dir += Vector2.left;
            if (Input.GetKey(KeyCode.D))
                dir += Vector2.right;
            _rb.AddForce(Vector2.up * (_mic.LevelMax() * verticalForce));
            /*
            if (Input.GetKeyDown(KeyCode.W)) 
                dir += Vector2.up;
            if (Input.GetKeyDown(KeyCode.S))
                dir += Vector2.down;
            */
            _rb.AddForce(dir.normalized * horizontalForce);
        }
    }
}