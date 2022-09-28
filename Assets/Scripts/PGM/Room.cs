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
    private Room topRoom;
    private Room bottomRoom;
    private Room leftRoom;
    private Room rightRoom;
    private List<MobInfo> _mobs;

    public string Scene { get; private set; }
    public Room TopRoom { get; set; }
    public Room BottomRoom { get; set; }
    public Room LeftRoom { get; set; }
    public Room RightRoom { get; set; }

    public Room(string sceneName)
    {
        Scene = sceneName;
        _mobs = new List<MobInfo>();
    }

    public void AddMobToRoom(GameObject mob, float x, float y)
    {
        MobInfo m = new MobInfo(mob, x, y);
        _mobs.Add(m);
    }

    public void MatchSceneToRoomConstraints()
    {
        GameObject ee = GameObject.Find("Exits/Entrances");
        if (ee != null)
        {
            if (LeftRoom == null)
            {
                ee.transform.Find("Left_Open").gameObject.SetActive(false);
                ee.transform.Find("Left_Closed").gameObject.SetActive(true);
            }
            else
            {
                ee.transform.Find("Left_Open").gameObject.SetActive(true);
                ee.transform.Find("Left_Closed").gameObject.SetActive(false);
            }
            if (TopRoom == null)
            {
                ee.transform.Find("Top_Open").gameObject.SetActive(false);
                ee.transform.Find("Top_Closed").gameObject.SetActive(true);
            }
            else
            {
                ee.transform.Find("Top_Open").gameObject.SetActive(true);
                ee.transform.Find("Top_Closed").gameObject.SetActive(false);
            }
            if (RightRoom == null)
            {
                ee.transform.Find("Right_Open").gameObject.SetActive(false);
                ee.transform.Find("Right_Closed").gameObject.SetActive(true);
            }
            else
            {
                ee.transform.Find("Right_Open").gameObject.SetActive(true);
                ee.transform.Find("Right_Closed").gameObject.SetActive(false);
            }
            if (BottomRoom == null)
            {
                ee.transform.Find("Bottom_Open").gameObject.SetActive(false);
                ee.transform.Find("Bottom_Closed").gameObject.SetActive(true);
            }
            else
            {
                ee.transform.Find("Bottom_Open").gameObject.SetActive(true);
                ee.transform.Find("Bottom_Closed").gameObject.SetActive(false);
            }
        }
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
