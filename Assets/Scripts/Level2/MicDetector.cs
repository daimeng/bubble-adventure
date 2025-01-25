using System;
using UnityEngine;
using UnityEngine.UI;

namespace Level2
{
    public class MicDetector : MonoBehaviour
    {
        private string _device;
      
        //mic initialization
        private void InitMic()
        {
            _device ??= Microphone.devices[0];
            _clipRecord = Microphone.Start(_device, true, 999, 44100);
        }

        private void StopMicrophone()
        {
            Microphone.End(_device);
        }


        private AudioClip _clipRecord;
        private const int SampleWindow = 128;

        [SerializeField] private Slider slider;
        [SerializeField] private float volSensitivity;

        //get data from microphone into audioclip
        public float LevelMax()
        {
            float levelMax = 0;
            var waveData = new float[SampleWindow];
            var micPosition = Microphone.GetPosition(null)-(SampleWindow+1); // null means the first microphone
            if (micPosition < 0) return 0;
            _clipRecord.GetData(waveData, micPosition);
            // Getting a peak on the last 128 samples
            for (int i = 0; i < SampleWindow; i++) {
                float wavePeak = waveData[i] * waveData[i];
                if (levelMax < wavePeak) {
                    levelMax = wavePeak;
                }
            }

            var volLevel = levelMax * volSensitivity;
            slider.value = volLevel;
            return volLevel;
        }

        private bool _isInitialized;
        // start mic when scene starts
        private void OnEnable()
        {
            InitMic();
            _isInitialized=true;
        }
      
        //stop mic when loading a new level or quit application
        private void OnDisable()
        {
            StopMicrophone();
        }

        private void OnDestroy()
        {
            StopMicrophone();
        }
      
      
        // make sure the mic gets started & stopped when application gets focused
        private void OnApplicationFocus(bool focus) {
            if (focus)
            {
                //Debug.Log("Focus");

                if (_isInitialized) return;
                //Debug.Log("Init Mic");
                InitMic();
                _isInitialized=true;
            }      
            else
            {
                //Debug.Log("Pause");
                StopMicrophone();
                //Debug.Log("Stop Mic");
                _isInitialized=false;
              
            }
        }
    }
}