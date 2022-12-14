using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.Tilemaps;

public class MapController : MonoBehaviour
{
    [Header("Map Settings")]
    public int maxWidth;
    public int maxHeight;
    public int numOfRooms;
    public string roomType;

    [Header("Mob Lists")]
    public List<GameObject> RedMobs;

    [Header("Room Clear Reward")]
    public List<GameObject> Rewards;

    [Header("Player Reference")]
    public GameObject player;
    public GameObject cinemachineCamera;

    public Map Map { get; private set; }
    public Direction PreviousRoomDir { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        GenerateAndLoadMap();
    }

    void OnDestroy()
    {
        SceneManager.activeSceneChanged -= ChangedActiveScene;
    }

    public void GenerateAndLoadMap()
    {
        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, numOfRooms, roomType, RedMobs, Rewards);
        SceneManager.LoadScene(Map.CurrentRoom.Scene);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        GameObject roomController = GameObject.Find("RoomController");
        if (roomController != null)
        {
            RoomController controller = roomController.GetComponent<RoomController>();
            controller.Room = Map.CurrentRoom;
            controller.SpawnEnemies(player);
            controller.UpdatePlayerPosition(PreviousRoomDir, player);
            controller.SetCameraConfiner(cinemachineCamera);
            controller.MatchSceneWithRoomProperties();
        }
        else
        {
            roomController = GameObject.Find("BossRoomController");
            if (roomController != null)
            {
                BossRoomController controller = roomController.GetComponent<BossRoomController>();
                controller.SetPlayerAtEnterPoint(player);
                controller.SetCameraConfiner(cinemachineCamera);
            }
        }
    }
}
