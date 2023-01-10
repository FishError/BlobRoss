using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Map
{
    public Room[,] Array2D { get; set; }
    public Room StartRoom { get; private set; }
    public Room CurrentRoom { get; set; }
    public Room PreviousRoom { get; set; }

    public List<NavMeshSurface2d> navMeshSurfaces;

    public Map(Room startRoom, Room[,] array2D)
    {
        StartRoom = startRoom;
        CurrentRoom = StartRoom;
        Array2D = array2D;
    }
}
