using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

enum Direction
{
    Left,
    Right,
    Up,
    Down
}

public class PGM
{
    public static Map ProcedurallyGenerateMap(int maxWidth, int maxHeight, string roomType)
    {
        System.Random random = new System.Random();
        Room[,] matrix = new Room[maxWidth, maxHeight]; ;
        int[] start, end;
        Direction dir;

        Array values = typeof(Direction).GetEnumValues();
        dir = (Direction)values.GetValue(random.Next(values.Length));

        switch (dir)
        {
            case Direction.Right:
                start = new int[] { 0, random.Next(0, maxHeight - 1) };
                end = new int[] { maxWidth - 1, random.Next(0, maxHeight - 1) };
                break;
            case Direction.Left:
                start = new int[] { maxWidth - 1, random.Next(0, maxHeight - 1) };
                end = new int[] { 0, random.Next(0, maxHeight - 1) };
                break;
            case Direction.Down:
                start = new int[] { random.Next(0, maxWidth - 1), 0 };
                end = new int[] { random.Next(0, maxWidth - 1), maxHeight - 1 };
                break;
            case Direction.Up:
                start = new int[] { random.Next(0, maxWidth - 1), maxHeight - 1 };
                end = new int[] { random.Next(0, maxWidth - 1), 0 };
                break;
            default:
                start = new int[] { 0, 0 };
                end = new int[] { 0, 0 };
                break;
        }

        matrix[start[0], start[1]] = new Room(roomType + random.Next(1, 4));
        int[] current = start;
        while (!(current[0] == end[0] && current[1] == end[1]))
        {
            current = GetRandomAdjacentLocation(current, dir, matrix, random);
            if (matrix[current[0], current[1]] == null)
            {
                matrix[current[0], current[1]] = new Room(roomType + random.Next(1, 4));
            }
        }

        for (int x = 0; x < matrix.GetUpperBound(0); x++)
        {
            for (int y = 0; y < matrix.GetUpperBound(1); y++)
            {
                if (matrix[x, y] != null)
                {
                    Room room = matrix[x, y];
                    if (x < matrix.GetUpperBound(0) - 1 && matrix[x + 1, y] != null)
                        room.RightRoom = matrix[x + 1, y];

                    if (x > 0 && matrix[x - 1, y] != null)
                        room.LeftRoom = matrix[x - 1, y];

                    if (y < matrix.GetUpperBound(1) - 1 && matrix[x, y + 1] != null)
                        room.BottomRoom = matrix[x, y + 1];

                    if (y > 0 && matrix[x, y - 1] != null)
                        room.TopRoom = matrix[x, y - 1];
                }
            }
        }

        return new Map(matrix[start[0], start[1]]);
    }

    private static int[] GetRandomAdjacentLocation(int[] current, Direction dir, Room[,] matrix, System.Random r)
    {
        List<Direction> values = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

        if (current[0] == 0 || dir == Direction.Right)
            values.Remove(Direction.Left);

        if (current[0] == matrix.GetUpperBound(0) - 1 || dir == Direction.Left)
            values.Remove(Direction.Right);

        if (current[1] == 0 || dir == Direction.Down)
            values.Remove(Direction.Up);

        if (current[1] == matrix.GetUpperBound(1) - 1 || dir == Direction.Up)
            values.Remove(Direction.Down);

        int[] next = current.Select(i => i).ToArray();
        switch (values[r.Next(values.Count)])
        {
            case Direction.Left:
                next[0] -= 1;
                break;
            case Direction.Right:
                next[0] += 1;
                break;
            case Direction.Up:
                next[1] -= 1;
                break;
            case Direction.Down:
                next[1] += 1;
                break;
        }

        return next;
    }
}
