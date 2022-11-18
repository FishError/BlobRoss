using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfo
{
    public GameObject mob;
    public Vector2 position;

    public MobInfo(GameObject m, Vector2 pos)
    {
        mob = m;
        position = pos;
    }
}

public class Room
{
    public List<GameObject> Enemies { get; set; }
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

    public void AddMobToRoom(GameObject enemy)
    {
        Enemies.Add(enemy);
    }

    public void RemoveMobFromRoom()
    {
        // havent decided what method to use for this yet
    }

    public void UpdateMobInfo()
    {
        // needs to be developed in the future probably
    }
}
