using UnityEngine;
using UnityEngine.UI;

namespace Level2
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int defaultHp;
        [SerializeField] private Slider scrollbar;
        private int _curHp;
        private AudioManager _audioManager;
        
        private void Start()
        {
            _curHp = defaultHp;
            scrollbar.value = ((float)_curHp) / defaultHp;
            _audioManager = FindFirstObjectByType<AudioManager>();
        }

        public void Hurt(int dmg)
        {
            _curHp -= dmg;
            Debug.Log($"current hp: {_curHp}");
            scrollbar.value = ((float)_curHp) / defaultHp;
            _audioManager.PlayHurt();
        }
        
    }
}