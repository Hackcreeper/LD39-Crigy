using Entities;
using UnityEngine;

namespace Items
{
    public class Battery : MonoBehaviour
    {
        private bool destroyed = false;
        
        private void Update()
        {
            if (destroyed)
            {
                return;
            }
            
            if (Vector3.Distance(Player.instance.transform.position, transform.position) <= 1.6f)
            {
                Player.instance.energy.energy += 4;
                
                GetComponent<AudioSource>().Play();
                
                Destroy(transform.Find("GFX").gameObject);
                Invoke("DestroySelf", 2000);

                destroyed = true;
            }
        }

        private void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}