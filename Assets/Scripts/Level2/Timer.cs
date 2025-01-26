using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Level2
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float time;
        private float _remainTime;
        [SerializeField] private float updateTimeFrame;
        [SerializeField] private Slider progressBar;
        
        private IEnumerator Counter()
        {
            while (true)
            {
                yield return new WaitForSeconds(updateTimeFrame);
                _remainTime -= updateTimeFrame;
                progressBar.value = (time - _remainTime) / time;
            }
        }

        public float GetCurrentPercentage()
        {
            return (time - _remainTime) / time;
        }

        private void Start()
        {
            _remainTime = time;
            StartCoroutine(Counter());
        }
    }
}