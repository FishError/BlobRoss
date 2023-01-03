using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.Tilemaps;
using UnityEngine.AI;

public class MapController : MonoBehaviour
{
    [Header("Map Settings")]
    public int maxWidth;
    public int maxHeight;
    public int numOfRooms;
    public string roomType;

    [Header("Mob Lists")]
    public List<GameObject> RedMobs;

    [Header("NavMesh")]
    public NavMeshSurface2d navMeshSurface;

    [Header("Room Clear Reward")]
    public List<GameObject> Rewards;

    [Header("Player Reference")]
    public GameObject player;
    public GameObject cinemachineCamera;

    public Map Map { get; private set; }

    public List<RoomController> roomControllers { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.activeSceneChanged += ChangedActiveScene;
        StartCoroutine(GenerateAndLoadMap());

        roomControllers = new List<RoomController>();
    }

    /*void OnDestroy()
    {
        SceneManager.activeSceneChanged -= ChangedActiveScene;
    }*/

    public IEnumerator GenerateAndLoadMap()
    {
        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, numOfRooms, roomType, RedMobs, Rewards);
        yield return StartCoroutine(PGM.LoadMap(this));
        navMeshSurface.BuildNavMesh();
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        GameObject roomController = SceneManager.GetSceneAt(Map.StartRoom.index).GetRootGameObjects()[0];
        player.transform.position = roomController.transform.position;
    }

    public void LoadBossRoom()
    {
        foreach (RoomController rc in roomControllers)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(rc.Room.index));
        }

        SceneManager.LoadSceneAsync("dev_placeholder_boss");
    }

    /*private void ChangedActiveScene(Scene current, Scene next)
    {
        GameObject roomController = GameObject.Find("BossRoomController");
        if (roomController != null)
        {
            BossRoomController controller = roomController.GetComponent<BossRoomController>();
            controller.SetPlayerAtEnterPoint(player);
            controller.SetCameraConfiner(cinemachineCamera);
        }
    }*/
}
