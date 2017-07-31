using UnityEngine;

namespace Entities
{
    public class Turret : MonoBehaviour
    {
        public Transform shootSmallA;

        public Transform shootSmallB;

        public Transform shootBig;

        public GameObject bulletPrefab;

        public GameObject bigBulletPrefab;

        public void ShootSmall()
        {
            var go = Instantiate(bulletPrefab);
            go.transform.position = shootSmallA.position;
            go.transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y - 90,
                transform.rotation.eulerAngles.z
            );

            go = Instantiate(bulletPrefab);
            go.transform.position = shootSmallB.position;
            go.transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y - 90,
                transform.rotation.eulerAngles.z
            );
            
            GetComponent<AudioSource>().Play();
        }

        public void ShootAll()
        {
            ShootSmall();

            var go = Instantiate(bigBulletPrefab);
            go.transform.position = shootBig.position;
            go.transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y - 90,
                transform.rotation.eulerAngles.z
            );
        }

        private void Update()
        {
            var player = Player.instance.transform;
            
            transform.LookAt(player);
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y + 90,
                transform.rotation.eulerAngles.z
            );
        }

        private void Start()
        {
            Invoke("StartAnimation", 1);
        }

        private void StartAnimation()
        {
            GetComponent<Animator>().SetBool("start", true);
        }
    }
}