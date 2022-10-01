using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    public Room StartRoom { get; private set; }
    public Room CurrentRoom { get; set; }
    public Room PreviousRoom { get; set; }

    public Map(Room startRoom)
    {
        StartRoom = startRoom;
        CurrentRoom = StartRoom;
    }
}
