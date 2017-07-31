using UnityEngine;

namespace Level
{
    public class Room : MonoBehaviour
    {
        public bool roomOpenTop;

        public bool roomOpenBottom;

        public bool roomOpenRight;

        public bool roomOpenLeft;

        public Vector2 coordinates;

        public bool finished;
        
        private void Start()
        {
            EnableDoor("Top", roomOpenTop);
            EnableDoor("Bottom", roomOpenBottom);
            EnableDoor("Right", roomOpenRight);
            EnableDoor("Left", roomOpenLeft);
        }

        public void SetCoordinates(Vector2 coords)
        {
            coordinates = coords;
        }

        private void EnableDoor(string side, bool enable)
        {
            if (enable)
            {
                transform.Find("Wall_" + side).gameObject.SetActive(false);
                transform.Find("Wall_" + side + "_Door").gameObject.SetActive(true);
            }
            else
            {
                transform.Find("Wall_" + side).gameObject.SetActive(true);
                transform.Find("Wall_" + side + "_Door").gameObject.SetActive(false);
            }
        }
        
    }
}