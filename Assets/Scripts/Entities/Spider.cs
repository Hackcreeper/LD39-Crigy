using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entities
{
    public class Spider : MonoBehaviour
    {
        public float moveSpeed = 8f;
        
        private void Update()
        {
            var player = Player.instance.transform;
            
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (Player.instance.cooldown <= 0)
                {
                    Player.instance.energy.energy -= 10;
                    Player.instance.cooldown = .5f;
                    
                    Player.instance.energy.GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}