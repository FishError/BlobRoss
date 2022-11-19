using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public List<GameObject> Enemies { get; private set; }
    public GameObject Reward { get; set; }

    public string Scene { get; private set; }
    public Room TopRoom { get; set; }
    public Room BottomRoom { get; set; }
    public Room LeftRoom { get; set; }
    public Room RightRoom { get; set; }

    public Room(string sceneName)
    {
        Scene = sceneName;
        Enemies = new List<GameObject>();
    }

    public void AddEnemies(GameObject enemy)
    {
        Enemies.Add(enemy);
    }

    public void RemoveAllEnemies()
    {
        Enemies.Clear();
    }
}
