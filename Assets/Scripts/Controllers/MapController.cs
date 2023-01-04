using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.Tilemaps;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.UI;

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

    [Header("Loading Screen")]
    public GameObject loadingScreen;
    public Slider progressSlider;
    private int scenesLoaded;

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
        scenesLoaded = 0;
        progressSlider.value = 0;
        loadingScreen.SetActive(true);
        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, numOfRooms, roomType, RedMobs, Rewards);
        yield return StartCoroutine(LoadMap());
        navMeshSurface.BuildNavMesh();
        SpawnPlayer();
        yield return new WaitForSeconds(0.2f);
        loadingScreen.SetActive(false);
    }

    private void SpawnPlayer()
    {
        GameObject roomController = SceneManager.GetSceneAt(Map.StartRoom.index).GetRootGameObjects()[0];
        player.transform.position = roomController.transform.position;
    }

    public IEnumerator LoadMap()
    {
        Room[,] array2D = Map.Array2D;
        List<AsyncOperation> operations = new List<AsyncOperation>();
        for (int y = 0; y < array2D.GetUpperBound(0); y++)
        {
            for (int x = 0; x < array2D.GetUpperBound(1); x++)
            {
                if (array2D[y, x] != null)
                {
                    Room room = array2D[y, x];
                    int operationIndex = SceneManager.sceneCount;
                    room.index = operationIndex;
                    AsyncOperation operation = SceneManager.LoadSceneAsync(room.Scene, LoadSceneMode.Additive);
                    Vector2 pos = new Vector2(x * 35, y * -35);

                    operation.completed += (s) =>
                    {
                        Scene scene = SceneManager.GetSceneAt(operationIndex);
                        GameObject roomObject = scene.GetRootGameObjects()[0];
                        roomObject.transform.position = pos;
                        RoomController roomController = roomObject.GetComponent<RoomController>();
                        roomController.Room = room;
                        roomController.MatchSceneWithRoomProperties();
                        roomControllers.Add(roomController);
                        UpdateLoadingProgressSlider();
                    };

                    operations.Add(operation);
                }
            }
        }

        yield return new WaitUntil(() => operations.All(op => op.isDone));
    }

    public void LoadBossRoom()
    {
        foreach (RoomController rc in roomControllers)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(rc.Room.index));
        }

        SceneManager.LoadSceneAsync("dev_placeholder_boss");
    }

    private void UpdateLoadingProgressSlider()
    {
        scenesLoaded++;
        progressSlider.value = (float)scenesLoaded / numOfRooms;
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
