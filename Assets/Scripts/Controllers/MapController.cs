using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class MapController : MonoBehaviour
{
    [Header("Map Settings")]
    public int maxWidth;
    public int maxHeight;
    public int numOfRooms;
    public string roomType;

    [Header("Player Reference")]
    public GameObject player;
    public GameObject playerCamera;

    public Map Map { get; private set; }
    public Direction previousRoomDir { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, numOfRooms, roomType);
        SceneManager.LoadScene(Map.StartRoom.Scene);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        Map.CurrentRoom.MatchSceneToRoomConstraints();

        GameObject roomConnector = null;
        switch (previousRoomDir)
        {
            case Direction.Left:
                roomConnector = GameObject.Find("RoomConnectorLeft");
                break;
            case Direction.Right:
                roomConnector = GameObject.Find("RoomConnectorRight");
                break;
            case Direction.Up:
                roomConnector = GameObject.Find("RoomConnectorTop");
                break;
            case Direction.Down:
                roomConnector = GameObject.Find("RoomConnectorBottom");
                break;
        }

        if (roomConnector != null)
        {
            Transform spawnLocation = roomConnector.transform.Find("EntranceSpawn");
            if (spawnLocation != null)
            {
                player.transform.position = spawnLocation.position;
            }
        }
        SetCameraConfiner();
    }

    private void SetCameraConfiner()
    {
        var grid = GameObject.Find("Grid").GetComponent<PolygonCollider2D>();
        playerCamera.GetComponent<CinemachineConfiner>().m_BoundingShape2D = grid;
    }
}
