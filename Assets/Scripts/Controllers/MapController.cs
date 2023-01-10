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

    public Map Map { get; private set; }

    public List<RoomController> roomControllers { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateAndLoadMap());

        roomControllers = new List<RoomController>();
    }

    public IEnumerator GenerateAndLoadMap()
    {
        progressSlider.value = 0;
        loadingScreen.SetActive(true);
        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, numOfRooms, roomType, RedMobs, Rewards);
        yield return StartCoroutine(LoadMap(OnUpdateProgress, OnSceneLoaded, false));
    }

    private void SpawnPlayer()
    {
        GameObject roomController = SceneManager.GetSceneAt(Map.StartRoom.index).GetRootGameObjects()[0];
        player.transform.position = roomController.transform.position;
    }

    public IEnumerator LoadMap(System.Action<float> progress, System.Action<Scene, Vector2, Room> onSceneLoaded, bool activateDirectly)
    {
        Room[,] array2D = Map.Array2D;
        int totalScenesLoaded = 0;
        List<AsyncOperation> sceneLoadOperations = new List<AsyncOperation>();
        
        for (int y = 0; y < array2D.GetUpperBound(0); y++)
        {
            for (int x = 0; x < array2D.GetUpperBound(1); x++)
            {
                if (array2D[y, x] != null)
                {
                    Room room = array2D[y, x];
                    room.index = SceneManager.sceneCount;
                    Vector2 pos = new Vector2(x * 35, y * -35);

                    AsyncOperation operation = SceneManager.LoadSceneAsync(room.Scene, LoadSceneMode.Additive);
                    operation.allowSceneActivation = activateDirectly;

                    operation.completed += (s) =>
                    {
                        totalScenesLoaded++;
                        onSceneLoaded(SceneManager.GetSceneAt(room.index), pos, room);

                    };
                    
                    sceneLoadOperations.Add(operation);
                }
            }
        }

        float activeProgress = 0;
        float targetProgress = (activateDirectly) ? numOfRooms : 0.9f * numOfRooms;
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        while (!Mathf.Approximately(activeProgress, targetProgress))
        {
            activeProgress = 0;

            foreach (AsyncOperation op in sceneLoadOperations)
            {
                activeProgress += op.progress;
            }

            progress.Invoke(Mathf.InverseLerp(0, targetProgress + numOfRooms, activeProgress + totalScenesLoaded));

            yield return waitForSeconds;
        }

        if (!activateDirectly)
        {
            activeProgress = targetProgress;

            foreach (AsyncOperation op in sceneLoadOperations)
            {
                op.allowSceneActivation = true;
            }
        }

        while (totalScenesLoaded != numOfRooms)
        {
            yield return waitForSeconds;

            progress.Invoke(Mathf.InverseLerp(0, targetProgress + numOfRooms, activeProgress + totalScenesLoaded));
        }

        navMeshSurface.BuildNavMesh();
        SpawnPlayer();

        yield return waitForSeconds;
        loadingScreen.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, Vector2 pos, Room room)
    {
        GameObject roomObject = scene.GetRootGameObjects()[0];
        roomObject.transform.position = pos;
        RoomController roomController = roomObject.GetComponent<RoomController>();
        roomController.Room = room;
        roomController.MatchSceneWithRoomProperties();
        roomControllers.Add(roomController);
    }

    private void OnUpdateProgress(float progress)
    {
        progressSlider.value = progress;
    }

    public IEnumerator UnloadMapAndLoadBossRoom()
    {
        progressSlider.value = 0;
        loadingScreen.SetActive(true);

        int totalScenesUnloaded = 0;
        List<AsyncOperation> sceneUnloadOperations = new List<AsyncOperation>();

        foreach (RoomController rc in roomControllers)
        {
            AsyncOperation op = SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(rc.Room.index));
            sceneUnloadOperations.Add(op);
            op.completed += (s) =>
            {
                totalScenesUnloaded++;
            };
        }

        AsyncOperation bossSceneLoadOperation = SceneManager.LoadSceneAsync("dev_placeholder_boss");
        bossSceneLoadOperation.completed += (s) =>
        {
            Scene scene = SceneManager.GetSceneByName("dev_placeholder_boss");
            GameObject roomObject = scene.GetRootGameObjects()[0];
            BossRoomController roomController = roomObject.GetComponent<BossRoomController>();
            roomController.SetPlayerAtEnterPoint(player);
            roomController.SetCameraConfiner(cinemachineCamera);
        };

        float activeProgress = 0;
        float targetProgress = numOfRooms + 1;
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);

        while (!Mathf.Approximately(activeProgress, targetProgress))
        {
            activeProgress = 0;

            foreach (AsyncOperation op in sceneUnloadOperations)
            {
                activeProgress += op.progress;
            }

            //progress.Invoke(Mathf.InverseLerp(0, targetProgress + numOfRooms, activeProgress + totalScenesLoaded));

            yield return waitForSeconds;
        }

        while (totalScenesUnloaded != numOfRooms && bossSceneLoadOperation.isDone)
        {
            yield return waitForSeconds;

            //progress.Invoke(Mathf.InverseLerp(0, targetProgress + numOfRooms, activeProgress + totalScenesUnloaded + 1));
        }

        yield return waitForSeconds;
        loadingScreen.SetActive(false);
    }

}
