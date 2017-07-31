using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities
{
    public class Bullet : MonoBehaviour
    {
        public bool isBad;
        
        private void FixedUpdate()
        {
            transform.Translate(20 * Vector3.forward * Time.deltaTime, Space.Self);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy") && !isBad)
            {
                Player.instance.GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Player") && isBad)
            {
                if (Player.instance.cooldown <= 0)
                {
                    Player.instance.energy.energy -= 10;
                    Player.instance.cooldown = .5f;
                    
                    Player.instance.energy.GetComponent<AudioSource>().Play();
                }
            }

            Destroy(gameObject);
        }
    }
}