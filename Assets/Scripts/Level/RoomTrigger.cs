using Entities;
using UnityEngine;

namespace Level
{
    public class RoomTrigger : MonoBehaviour
    {
        public Direction direction;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                return;
            }
         
            if (Player.instance.playerCamera.isReady)
            {
                var coords = GetNewRoom();
                RoomGenerator.instance.InstantiatePrefab(coords);
                Player.instance.playerCamera.AdjustToRoom(coords);

                var coord = GetNewPosition(coords);
                Player.instance.transform.position = new Vector3(
                    coord.x,
                    0,
                    coord.y
                );
            }
        }

        private Vector2 GetNewRoom()
        {
            var original = Player.instance.currentRoom.coordinates;
            switch (direction)
            {
                case Direction.Down:
                    original.x -= 1;
                    break;

                case Direction.Up:
                    original.x += 1;
                    break;

                case Direction.Left:
                    original.y += 1;
                    break;

                case Direction.Right:
                    original.y -= 1;
                    break;
            }
            return original;
        }

        private Vector2 GetNewPosition(Vector2 newCoords)
        {
            newCoords *= 25;

            switch (direction)
            {
                case Direction.Right:
                    return newCoords + new Vector2(0, 11);
                case Direction.Left:
                    return newCoords + new Vector2(0, -11);
                case Direction.Up:
                    return newCoords + new Vector2(-11, 0);
                case Direction.Down:
                    return newCoords + new Vector2(11, 0);
            }

            return newCoords;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}