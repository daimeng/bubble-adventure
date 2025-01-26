using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level2
{
    public class BackgroundMover : MonoBehaviour
    {
        [SerializeField] private float endY;
        [SerializeField] private Timer timer;
        private float _startY;
        private void Start()
        {
            _startY = transform.position.y;
            
        }

        private void Update()
        {
            if (transform.position.y <= endY)
                SceneManager.LoadScene("dialogue2");
            var delta = (endY - _startY) * timer.GetCurrentPercentage();
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(position.x, _startY + delta, position.z);
            transform1.position = position;
        }
    }
}