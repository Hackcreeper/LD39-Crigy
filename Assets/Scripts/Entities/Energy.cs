using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities
{
    public class Energy : MonoBehaviour
    {
        public int energy = 10;

        public int max = 10;
        
        private float timer = 1f;
        
        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                energy--;
                timer = 1f;

                if (energy <= 0 && !Player.instance.won)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}