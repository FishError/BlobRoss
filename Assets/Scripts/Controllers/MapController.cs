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

    [Header("Player Reference")]
    public GameObject player;
    public GameObject cinemachineCamera;

    public RoomController CurrentRoomController { get; set; }
    public Map Map { get; private set; }
    public Direction PreviousRoomDir { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        GenerateAndLoadMap();
    }

    public void GenerateAndLoadMap()
    {
        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, numOfRooms, roomType, RedMobs);
        SceneManager.LoadScene(Map.StartRoom.Scene);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        GameObject roomController = GameObject.Find("RoomController");
        if (roomController != null)
        {
            CurrentRoomController = roomController.GetComponent<RoomController>();
            CurrentRoomController.Room = Map.CurrentRoom;
            CurrentRoomController.SpawnEnemies(player);
            CurrentRoomController.UpdatePlayerPosition(PreviousRoomDir, player);
            CurrentRoomController.SetCameraConfiner(cinemachineCamera);
            CurrentRoomController.MatchSceneWithRoomProperties(Map.CurrentRoom);
        }
    }
}
