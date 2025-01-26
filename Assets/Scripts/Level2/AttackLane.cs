using UnityEngine;

namespace Level2
{
    public class AttackLane : MonoBehaviour
    {
        [SerializeField] private GameObject bullet;
        private void OnEnable()
        {
            Debug.Log($"enable {transform.parent.name}");
            var transform1 = transform;
            var parent = transform1.parent;
            var current = Instantiate(bullet, transform1.position, transform1.rotation, parent);
            current.GetComponent<Bullet>().AttackLane = parent.gameObject;
        }
    }
}