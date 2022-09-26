using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string scene;
    private string topRoom;
    private string bottomRoom;
    private string leftRoom;
    private string rightRoom;

    public string Scene { get; }
    public string TopRoom { get; }
    public string BottomRoom { get; }
    public string LeftRoom { get; }
    public string RightRoom { get; }

    public Room(string sceneName)
    {
        scene = sceneName;
    }
}
