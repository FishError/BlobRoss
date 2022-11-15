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
    public List<GameObject> Enemies;

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

    public void AddMobToRoom(GameObject enemy, Vector2 pos)
    {
        Enemies.Add(enemy);
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
