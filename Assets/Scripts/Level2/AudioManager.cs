using System;
using UnityEngine;

namespace Level2
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip hurt;
        [SerializeField] private AudioClip warning;
        private AudioSource _audioSource;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayHurt()
        {
            _audioSource.clip = hurt;
            _audioSource.Play();
        }

        public void PlayWarn()
        {
            _audioSource.clip = warning;
            _audioSource.Play();
        }
    }
}