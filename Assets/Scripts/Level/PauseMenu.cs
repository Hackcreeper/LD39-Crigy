using UnityEngine;

namespace Level
{
    public class PauseMenu : MonoBehaviour
    {
        public RectTransform pausePanel;

        public bool paused;

        public static PauseMenu instance;

        private void Update()
        {
            if (!paused)
            {
                if (!Input.GetKeyDown(KeyCode.Escape)) return;
                
                paused = true;
                Time.timeScale = 0;
                pausePanel.gameObject.SetActive(true);
            }
            else
            {
                if (!Input.anyKeyDown) return;
                
                paused = false;
                Time.timeScale = 1;
                pausePanel.gameObject.SetActive(false);
            }
        }

        private void Awake()
        {
            instance = this;
        }
    }
}