using System;
using UnityEngine;

namespace Level2
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Vector2 vec;
        [SerializeField] private int dmg = 10;
        public GameObject AttackLane;
        private void Update()
        {
            transform.Translate(vec);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Health>().Hurt(dmg);
            }

            if (other.CompareTag("Wall"))
            {
                Destroy(gameObject);
                AttackLane.SetActive(false);
            }
        }
    }
}