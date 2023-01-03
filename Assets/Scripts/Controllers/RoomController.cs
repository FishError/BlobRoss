using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum RoomStates
{
    NotCleared,
    PlayerEntered,
    Cleared
}

public class RoomController : MonoBehaviour
{
    public Room Room { get; set; }

    public GameObject grid;
    public Transform enemySpawnAreas;
    public Transform enemies;
    public Transform playerSpawn;

    [Header("Dynamic Tilemaps")]
    public GameObject leftClosed;
    public GameObject rightClosed;
    public GameObject bottomClosed;
    public GameObject topClosed;

    public GameObject leftGate;
    public GameObject rightGate;
    public GameObject bottomGate;
    public GameObject topGate;

    #region Room States
    private RoomStates state;
    private bool oneEnemyRemaining;
    #endregion

    private void Start()
    {
        state = RoomStates.NotCleared;
    }

    private void Update()
    {
        switch (state)
        {
            case RoomStates.NotCleared:
                break;
            case RoomStates.PlayerEntered:
                if (enemies.childCount == 1 && !oneEnemyRemaining)
                {
                    Enemy enemy = enemies.GetChild(0).GetComponent<Enemy>();
                    enemy.lootDrop = Room.Reward;
                    oneEnemyRemaining = true;
                }

                if (enemies.childCount == 0)
                {
                    Room.RemoveAllEnemies();
                    DeactivateGates();
                    state = RoomStates.Cleared;
                }
                break;
            case RoomStates.Cleared:
                break;
            default:
                break;
        }
    }

    public void SetCameraConfiner(GameObject cinemachineCamera)
    {
        cinemachineCamera.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = grid.GetComponent<Collider2D>();
    }

    public void MatchSceneWithRoomProperties()
    {
        leftClosed.SetActive(Room.LeftRoom == null);
        rightClosed.SetActive(Room.RightRoom == null);
        bottomClosed.SetActive(Room.BottomRoom == null);
        topClosed.SetActive(Room.TopRoom == null);
    }

    public void ActivateGates()
    {
        leftGate.SetActive(Room.LeftRoom != null);
        rightGate.SetActive(Room.RightRoom != null);
        bottomGate.SetActive(Room.BottomRoom != null);
        topGate.SetActive(Room.TopRoom != null);
    }

    public void DeactivateGates()
    {
        leftGate.SetActive(false);
        rightGate.SetActive(false);
        bottomGate.SetActive(false);
        topGate.SetActive(false);
    }

    public void SpawnEnemies(GameObject player)
    {
        if (enemySpawnAreas != null)
        {
            foreach (GameObject enemy in Room.Enemies)
            {
                Transform area = enemySpawnAreas.transform.GetChild(Random.Range(0, enemySpawnAreas.transform.childCount));
                Collider2D areaBounds = area.GetComponent<Collider2D>();
                if (areaBounds is BoxCollider2D)
                {
                    BoxCollider2D boxBounds = (BoxCollider2D)areaBounds;
                    float x = Random.Range(-boxBounds.size.x / 2, boxBounds.size.x / 2);
                    float y = Random.Range(-boxBounds.size.y / 2, boxBounds.size.y / 2);
                    Vector2 pos = new Vector2(area.position.x + x, area.position.y + y);
                    GameObject enemyObject = Instantiate(enemy, pos, Quaternion.identity);
                    enemyObject.GetComponent<Enemy>().target = player;
                    enemyObject.transform.SetParent(enemies);
                }
            }
        }

        // Dynamic method I came up with but is buggy and sometimes spawns enemies in walls
        // keeping this here for now just for reference in the future

        /*GameObject unwalkable = GameObject.Find("Unwalkable");
        if (unwalkable != null)
        {
            Tilemap[] unWalkableTilemaps = unwalkable.GetComponentsInChildren<Tilemap>(C);
            List<Vector2> avaliableSpawnPos = new List<Vector2>();
            foreach (Tilemap tilemap in unWalkableTilemaps)
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

            foreach (GameObject enemy in Map.CurrentRoom.Enemies)
            {
                Vector2 randomPos = avaliableSpawnPos[Random.Range(0, avaliableSpawnPos.Count - 1)];
                GameObject mob = Instantiate(enemy, randomPos, Quaternion.identity);
                mob.GetComponent<Enemy>().target = player;
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (state == RoomStates.NotCleared)
            {
                if (Room.Enemies.Count > 0)
                {
                    state = RoomStates.PlayerEntered;
                    ActivateGates();
                    SpawnEnemies(collision.gameObject);
                }
                else
                {
                    state = RoomStates.Cleared;
                }
            }
        }
    }
}
