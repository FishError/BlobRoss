using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map
{
    private Room startRoom;
    private Room currentRoom;

    public Room StartRoom { get; }
    public Room CurrentRoom { get; set; }

    public Map()
    {

    }
}
