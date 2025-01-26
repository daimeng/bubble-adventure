using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class SceneReloader : MonoBehaviour
    {
        public void ReloadCurrentScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}