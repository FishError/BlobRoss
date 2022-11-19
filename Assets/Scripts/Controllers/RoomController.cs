using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public Room Room { get; set; }

    public GameObject grid;
    public GameObject exitsAndEntrances;
    public Transform enemySpawnAreas;
    public Transform enemies;

    [Header("Dynamic Tilemaps")]
    public GameObject leftOpen;
    public GameObject leftClosed;
    public GameObject rightOpen;
    public GameObject rightClosed;
    public GameObject bottomOpen;
    public GameObject bottomClosed;
    public GameObject topOpen;
    public GameObject topClosed;

    [Header("Room Connectors")]
    public GameObject roomConnectorLeft;
    public GameObject roomConnectorRight;
    public GameObject roomConnectorDown;
    public GameObject roomConnectorUp;

    private bool canLeave;

    private void Update()
    {
        if (enemies.childCount == 0 && !canLeave)
        {
            Room.RemoveAllEnemies();
            canLeave = true;
            roomConnectorLeft.SetActive(true);
            roomConnectorRight.SetActive(true);
            roomConnectorDown.SetActive(true);
            roomConnectorUp.SetActive(true);
        }
    }

    public void SetCameraConfiner(GameObject cinemachineCamera)
    {
        cinemachineCamera.GetComponentInChildren<CinemachineConfiner>().m_BoundingShape2D = grid.GetComponent<PolygonCollider2D>();
    }

    public void UpdatePlayerPosition(Direction previousRoomDir, GameObject player)
    {
        GameObject roomConnector = null;
        switch (previousRoomDir)
        {
            case Direction.Left:
                roomConnector = roomConnectorLeft;
                break;
            case Direction.Right:
                roomConnector = roomConnectorRight;
                break;
            case Direction.Up:
                roomConnector = roomConnectorUp;
                break;
            case Direction.Down:
                roomConnector = roomConnectorDown;
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
    }

    public void MatchSceneWithRoomProperties()
    {
        leftOpen.SetActive(Room.LeftRoom != null);
        leftClosed.SetActive(Room.LeftRoom == null);

        rightOpen.SetActive(Room.RightRoom != null);
        rightClosed.SetActive(Room.RightRoom == null);
        
        bottomOpen.SetActive(Room.BottomRoom != null);
        bottomClosed.SetActive(Room.BottomRoom == null);
        
        topOpen.SetActive(Room.TopRoom != null);
        topClosed.SetActive(Room.TopRoom == null);
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
}
