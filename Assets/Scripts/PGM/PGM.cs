using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Direction
{
    Left,
    Right,
    Up,
    Down
}

public class PGM
{
    public static Map ProcedurallyGenerateMap(int maxWidth, int maxHeight, int numOfRooms, string roomType, List<GameObject> mobList)
    {
        System.Random random = new System.Random();
        Room[,] array2D = new Room[maxHeight + 1, maxWidth + 1];

        int[] start = new int[] { random.Next(0, maxWidth), random.Next(0, maxHeight) };
        array2D[start[0], start[1]] = new Room(roomType + "_start");
        
        int roomCount = 1;
        int[] current = start;
        while (roomCount != numOfRooms)
        {
            List<Direction> avaliableDirections = GetAvailableDirections(current, array2D);
            Direction randomDirection = avaliableDirections[random.Next(avaliableDirections.Count)];
            current = GetAdjacentLocation(current, randomDirection);

            if (array2D[current[0], current[1]] == null)
            {
                array2D[current[0], current[1]] = CreateRandomRoom(roomType, mobList, random);
                roomCount++;
            }
        }

        for (int y = 0; y < array2D.GetUpperBound(0); y++)
        {
            for (int x = 0; x < array2D.GetUpperBound(1); x++)
            {
                if (array2D[x, y] != null)
                {
                    Room room = array2D[x, y];
                    if (x < array2D.GetUpperBound(0) - 1 && array2D[x + 1, y] != null)
                        room.BottomRoom = array2D[x + 1, y];

                    if (x > 0 && array2D[x - 1, y] != null)
                        room.TopRoom = array2D[x - 1, y];

                    if (y < array2D.GetUpperBound(1) - 1 && array2D[x, y + 1] != null)
                        room.RightRoom = array2D[x, y + 1];

                    if (y > 0 && array2D[x, y - 1] != null)
                        room.LeftRoom = array2D[x, y - 1];
                }
            }
        }

        return new Map(array2D[start[0], start[1]]);
    }

    private static List<Direction> GetAvailableDirections(int[] current, Room[,] matrix)
    {
        List<Direction> values = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

        if (current[0] == 0)
            values.Remove(Direction.Up);

        if (current[0] == matrix.GetUpperBound(0) - 1)
            values.Remove(Direction.Down);

        if (current[1] == 0)
            values.Remove(Direction.Left);

        if (current[1] == matrix.GetUpperBound(1) - 1)
            values.Remove(Direction.Right);

        return values;
    }

    private static int[] GetAdjacentLocation(int[] current, Direction dir)
    {
        int[] next = current.Select(i => i).ToArray();
        switch (dir)
        {
            case Direction.Left:
                next[1] -= 1;
                break;
            case Direction.Right:
                next[1] += 1;
                break;
            case Direction.Up:
                next[0] -= 1;
                break;
            case Direction.Down:
                next[0] += 1;
                break;
        }

        return next;
    }

    private static Room CreateRandomRoom(string roomType, List<GameObject> mobList, System.Random random)
    {
        Room room = new Room(roomType + "_" + random.Next(1, 3));
        int numOfMobs = random.Next(4, 7);
        for (int i = 0; i < numOfMobs; i++)
        {
            GameObject mob = mobList[random.Next(mobList.Count)];
            room.AddMobToRoom(mob.gameObject, Vector2.zero);
        }
        return room;
    }
}
