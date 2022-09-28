using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private Room startRoom;
    private Room currentRoom;

    public Room StartRoom { get; private set; }
    public Room CurrentRoom { get; set; }

    public Map(Room startingRoom)
    {
        StartRoom = startingRoom;
        CurrentRoom = startRoom;
    }
}
