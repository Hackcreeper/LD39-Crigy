using Level;
using UnityEngine;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 13f;

        public Room currentRoom;

        public PlayerCamera playerCamera;

        public Animator playerAnimator;

        public static Player instance;

        public Energy energy;

        public GameObject batteryPrefab;
        
        private Vector3 velocity;

        public bool won;

        public float cooldown;
        
        private void Update()
        {
            cooldown -= Time.deltaTime;
            
            if (playerCamera.isReady && !won)
            {
                velocity = new Vector3(
                    Input.GetAxis("Horizontal"),
                    0,
                    Input.GetAxis("Vertical")
                );

                playerAnimator.SetBool("shooting", Input.GetMouseButton(0));
                if (Input.GetMouseButton(0))
                {
                    RotateToMouse();
                }
                else
                {
                    RotateBaseOnDirection();
                }
            }
            else
            {
                velocity = Vector3.zero;
            }
        }

        private void RotateToMouse()
        {
            var pos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(-angle + 90, Vector3.up);
        }

        private void RotateBaseOnDirection()
        {
            var angle = transform.rotation.eulerAngles.y;

            if (velocity.z > 0 && velocity.x == 0) // 1. UP
            {
                angle = 0;
            }
            else if (velocity.z < 0 && velocity.x == 0) // DOWN
            {
                angle = 180;
            }
            else if (velocity.z == 0 && velocity.x < 0) // LEFT
            {
                angle = 270;
            }
            else if (velocity.z == 0 && velocity.x > 0) // RIGHT
            {
                angle = 90;
            }
            else if (velocity.z > 0 && velocity.x < 0) // TOP LEFT
            {
                angle = 315;
            }
            else if (velocity.z > 0 && velocity.x > 0) // TOP RIGHT
            {
                angle = 45;
            }
            else if (velocity.z < 0 && velocity.x < 0)
            {
                angle = 225;
            }
            else if (velocity.z < 0 && velocity.x > 0)
            {
                angle = 135;
            }
            
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }

        private void FixedUpdate()
        {
            var speed = moveSpeed + (cooldown > 0f ? 2 : 0);
            
            GetComponent<CharacterController>().SimpleMove(velocity * speed);
        }

        private void Awake()
        {
            instance = this;
        }
    }
}