using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class OpeningSceneChanger : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.LoadScene("Test");
        }
    }
}