using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Level
{
    public class RoomGenerator : MonoBehaviour
    {
        public GameObject roomPrefab;

        public GameObject xRoomPrefab;

        public GameObject spikeRoomPrefab;

        public GameObject bossRoomPrefab;

        private Dictionary<Vector2, GameObject> structure;

        public static RoomGenerator instance;

        private void Awake()
        {
            instance = this;

            BuildStructure();
            InstantiatePrefab(new Vector2(0, 0));
        }

        private void BuildStructure()
        {
            structure = new Dictionary<Vector2, GameObject>()
            {
                {new Vector2(0, 0), roomPrefab},
                {new Vector2(0, -1), roomPrefab},
                {new Vector2(1, -1), roomPrefab},
                {new Vector2(-1, -1), roomPrefab},
                {new Vector2(-1, -2), xRoomPrefab},
                {new Vector2(-1, -3), roomPrefab},
                {new Vector2(-2, -2), roomPrefab},
                {new Vector2(0, 1), spikeRoomPrefab},
                {new Vector2(0, 2), roomPrefab},
                {new Vector2(1, 1), roomPrefab},
                {new Vector2(-1, 1), roomPrefab},
                {new Vector2(-2, 1), roomPrefab},
                {new Vector2(-2, 2), xRoomPrefab},
                {new Vector2(2, 1), roomPrefab},
                {new Vector2(3, 1), roomPrefab},
                {new Vector2(3, 0), spikeRoomPrefab},
                {new Vector2(3, -1), roomPrefab},
                {new Vector2(4, 0), roomPrefab},
                {new Vector2(5, 0), xRoomPrefab},
                {new Vector2(4, 2), roomPrefab},
                {new Vector2(3, 2), roomPrefab},
                {new Vector2(5, 1), roomPrefab},
                {new Vector2(5, 2), spikeRoomPrefab},
                {new Vector2(6, 1), roomPrefab},
                {new Vector2(7, 1), roomPrefab},
                {new Vector2(8, 1), bossRoomPrefab}
            };
        }

        public void InstantiatePrefab(Vector2 coords)
        {
            if (Player.instance.currentRoom != null)
            {
                Destroy(Player.instance.currentRoom.gameObject);
            }

            var room = structure[coords];

            var go = Instantiate(room);
            go.transform.position = new Vector3(coords.x * 25, 0, coords.y * 25);

            SetTopWall(coords, go);
            SetBottomWall(coords, go);
            SetLeftWall(coords, go);
            SetRightWall(coords, go);

            go.GetComponent<Room>().SetCoordinates(coords);

            Player.instance.currentRoom = go.GetComponent<Room>();

            if (coords == Vector2.zero)
            {
                Destroy(go.transform.Find("Enemies").gameObject);

                go.transform.Find("Wall_Left_Door").Find("Door_Left").gameObject.SetActive(false);
                go.transform.Find("Wall_Right_Door").Find("Door_Right").gameObject.SetActive(false);
                go.transform.Find("Wall_Top_Door").Find("Door_Top").gameObject.SetActive(false);
                go.transform.Find("Wall_Bottom_Door").Find("Door_Bottom").gameObject.SetActive(false);

                go.GetComponent<Room>().finished = true;
            }
            else
            {
                go.transform.Find("Wall_Left_Door").Find("Door_Left").gameObject.SetActive(true);
                go.transform.Find("Wall_Right_Door").Find("Door_Right").gameObject.SetActive(true);
                go.transform.Find("Wall_Top_Door").Find("Door_Top").gameObject.SetActive(true);
                go.transform.Find("Wall_Bottom_Door").Find("Door_Bottom").gameObject.SetActive(true);
            }
        }

        private void SetTopWall(Vector2 coords, GameObject room)
        {
            var key = new Vector2(coords.x + 1, coords.y);
            room.GetComponent<Room>().roomOpenTop = structure.ContainsKey(key);
        }

        private void SetBottomWall(Vector2 coords, GameObject room)
        {
            var key = new Vector2(coords.x - 1, coords.y);
            room.GetComponent<Room>().roomOpenBottom = structure.ContainsKey(key);
        }

        private void SetLeftWall(Vector2 coords, GameObject room)
        {
            var key = new Vector2(coords.x, coords.y + 1);
            room.GetComponent<Room>().roomOpenLeft = structure.ContainsKey(key);
        }

        private void SetRightWall(Vector2 coords, GameObject room)
        {
            var key = new Vector2(coords.x, coords.y - 1);
            room.GetComponent<Room>().roomOpenRight = structure.ContainsKey(key);
        }

        private void Update()
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && !Player.instance.currentRoom.finished)
            {
                Invoke("OpenDoors", .8f);

                SpawnBattery();

                Player.instance.currentRoom.finished = true;
            }
        }

        public void SpawnBattery()
        {
            var battery = Instantiate(Player.instance.batteryPrefab);
            battery.transform.position = new Vector3(
                Player.instance.currentRoom.coordinates.x * 25,
                5f,
                Player.instance.currentRoom.coordinates.y * 25
            );
            battery.transform.rotation = Quaternion.Euler(
                Random.Range(0, 359),
                Random.Range(0, 359),
                Random.Range(0, 359)
            );
        }

        private void OpenDoors()
        {
            var room = Player.instance.currentRoom;
            
            room.transform.Find("Wall_Left_Door").Find("Door_Left").gameObject.SetActive(false);
            room.transform.Find("Wall_Right_Door").Find("Door_Right").gameObject.SetActive(false);
            room.transform.Find("Wall_Top_Door").Find("Door_Top").gameObject.SetActive(false);
            room.transform.Find("Wall_Bottom_Door").Find("Door_Bottom").gameObject.SetActive(false);
            
            GetComponent<AudioSource>().Play();
        }
    }
}