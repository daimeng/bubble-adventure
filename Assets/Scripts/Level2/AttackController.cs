using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level2
{
    public class AttackController : MonoBehaviour
    {
        private List<GameObject> _attackLanes = new List<GameObject>();
        [SerializeField] private float randTime;
        [SerializeField] private float probability;

        private IEnumerator RandomEnable()
        {
            while (true)
            {
                yield return new WaitForSeconds(randTime);
                foreach (var lane in _attackLanes)
                    lane.SetActive(Random.Range(0.0f, 1.0f) <= probability);
            }
        }

        private void Start()
        {
            foreach (var lane in FindObjectsByType<AttackLane>(FindObjectsInactive.Include, FindObjectsSortMode.None))
                _attackLanes.Add(lane.transform.parent.gameObject);
            StartCoroutine(RandomEnable());
        }
    }
}