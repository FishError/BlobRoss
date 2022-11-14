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

    public Map Map { get; private set; }
    public Direction previousRoomDir { get; set; }

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
        Map.CurrentRoom.MatchSceneToRoomConstraints();

        GameObject unwalkable = GameObject.Find("Unwalkable");
        if (unwalkable != null)
        {
            Tilemap[] tilemaps = unwalkable.GetComponentsInChildren<Tilemap>();

            //TileBase[] t = tilemaps[0].GetTilesBlock(tilemaps[0].cellBounds);
            //print(tilemaps[0].CellToLocal(new Vector3Int(tilemaps[0].cellBounds.xMin, tilemaps[0].cellBounds.yMin, 0)));
            //print(tilemaps[1].HasTile(new Vector3Int(tilemaps[1].cellBounds.xMin, tilemaps[1].cellBounds.yMax, 0)));

            List<Vector2> avaliableSpawnPos = new List<Vector2>();
            foreach(Tilemap tilemap in tilemaps)
            {
                for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
                {
                    for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
                    {
                        Vector3Int pos = new Vector3Int(x, y, 0);
                        if (tilemap.HasTile(pos))
                        {
                            avaliableSpawnPos.Remove(tilemap.CellToLocal(pos));
                        }
                        else
                        {
                            avaliableSpawnPos.Add(tilemap.CellToLocal(pos));
                        }
                    }
                }
            }
            /*for (int x = tilemaps[0].cellBounds.xMin; x < tilemaps[0].cellBounds.xMax; x++)
            {
                for (int y = tilemaps[0].cellBounds.yMin; y < tilemaps[0].cellBounds.yMax; y++)
                {
                    Vector3Int pos = new Vector3Int(x, y, 0);
                    if (tilemaps[0].HasTile(pos))
                    {
                        avaliableSpawnPos.Remove(tilemaps[0].CellToLocal(pos));
                    }
                    else
                    {
                        avaliableSpawnPos.Add(tilemaps[0].CellToLocal(pos));
                    }
                }
            }*/
            Vector2 p = avaliableSpawnPos[Random.Range(0, avaliableSpawnPos.Count - 1)];
            //print(p);
            GameObject mob = Instantiate(RedMobs[0], p, Quaternion.identity);
            mob.GetComponent<Enemy>().target = player;
        }

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
        cinemachineCamera.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = grid;
    }
}
