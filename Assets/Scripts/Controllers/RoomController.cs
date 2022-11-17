using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject grid;
    public Transform enemySpawnAreas;

    [Header("Room Connectors")]
    public GameObject roomConnectorLeft;
    public GameObject roomConnectorRight;
    public GameObject roomConnectorDown;
    public GameObject roomConnectorUp;

    public void SpawnEnemies(Room room, GameObject player)
    {
        if (enemySpawnAreas != null)
        {
            foreach (GameObject enemy in room.Enemies)
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
