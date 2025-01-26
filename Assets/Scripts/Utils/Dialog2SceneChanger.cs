using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class Dialog2SceneChanger : MonoBehaviour
    {
        private void OnEnable()
        {
            SceneManager.LoadScene("level3");
        }
    }
}