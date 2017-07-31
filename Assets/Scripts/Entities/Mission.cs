using System.Threading;
using Level;
using Microsoft.Win32;
using UnityEngine;

namespace Entities
{
    public class Mission : MonoBehaviour
    {
        public RectTransform activateText;
        
        public RectTransform wonText;

        public AudioSource music;

        public AudioClip winMusic;
        
        private int batteriesLeft = 40;

        private float timer;
        
        private void Update()
        {
            timer -= Time.deltaTime;
            
            var go = GameObject.FindGameObjectWithTag("Generator");
            if (go && !Player.instance.won)
            {
                activateText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Player.instance.won = true;

                    music.clip = winMusic;
                    music.Play();

                    foreach (var l in Player.instance.currentRoom.GetComponentsInChildren<Light>())
                    {
                        l.color = Color.green;
                    }

                    activateText.gameObject.SetActive(false);
                    
                    Invoke("EnableWin", 2);
                }
            } else if (Player.instance.won && batteriesLeft > 0 && timer <= 0)
            {
                RoomGenerator.instance.SpawnBattery();
                
                batteriesLeft--;
                timer = 0.05f;
            }
        }

        private void EnableWin()
        {
            wonText.gameObject.SetActive(true);
        }
    }
}