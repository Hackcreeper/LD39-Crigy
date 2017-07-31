using UnityEngine;

namespace Entities
{
    public class ShootingStar : MonoBehaviour
    {
        public GameObject bulletPrefab;

        public Transform spawnLocation;
        
        public void Shoot()
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawnLocation.position;
            bullet.transform.rotation = transform.rotation;

            GetComponent<AudioSource>().Play();
        }
    }
}