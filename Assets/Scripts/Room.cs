using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobInfo
{
    public GameObject mob;
    public float x_pos;
    public float y_pos;

    public MobInfo(GameObject m, float x, float y)
    {
        mob = m;
        x_pos = x;
        y_pos = y;
    }
}

public class Room
{
    private string scene;
    private string topRoom;
    private string bottomRoom;
    private string leftRoom;
    private string rightRoom;
    private MobInfo[] mobs;

    public string Scene { get; }
    public string TopRoom { get; }
    public string BottomRoom { get; }
    public string LeftRoom { get; }
    public string RightRoom { get; }

    public Room(string sceneName)
    {
        scene = sceneName;
    }

    public void addMobToRoom(GameObject mob, float x, float y)
    {
        MobInfo m = new MobInfo(mob, x, y);
    }

    public void removeMobFromRoom()
    {
        // havent decided what method to use for this yet
    }

    public void updateMobInfo()
    {
        // needs to be developed in the future probably
    }
}
