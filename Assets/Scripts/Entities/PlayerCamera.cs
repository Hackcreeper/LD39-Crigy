using UnityEngine;

namespace Entities
{
    public class PlayerCamera : MonoBehaviour
    {
        public Vector3 targetPosition;

        public bool isReady = false;
        
        public void AdjustToRoom(Vector2 room)
        {
            targetPosition = new Vector3(
                room.x * 25,
                22,
                room.y * 25
            );
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);

            isReady = Vector3.Distance(targetPosition, transform.position) <= 0.2f;
        }
    }
}