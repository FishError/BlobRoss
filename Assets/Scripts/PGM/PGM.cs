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

public class PGM: MonoBehaviour
{
    public static Map ProcedurallyGenerateMap(int maxWidth, int maxHeight, string roomType)
    {
        System.Random random = new System.Random();
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
        print(start[0] + " " + start[1]);
        print(end[0] + " " + end[1]);

        Room[,] matrix = new Room[maxWidth, maxHeight];
        matrix[start[0], start[1]] = new Room(roomType + "_" + random.Next(1, 4));
        int[] current = start;
        int otherDirCount = 0;
        while (!(current[0] == end[0] && current[1] == end[1]))
        {
            if ((dir == Direction.Left || dir == Direction.Right) && current[0] == end[0])
            {
                if (end[1] > current[1])
                    current[1]++;
                else
                    current[1]--;
            }
            else if ((dir == Direction.Up || dir == Direction.Down) && current[1] == end[1])
            {
                if (end[0] > current[0])
                    current[0]++;
                else
                    current[0]--;
            }
            else
            {
                List<Direction> avaliableDirections = GetAvailableDirections(current, dir, matrix, random);
                if (otherDirCount > 2)
                    avaliableDirections = new List<Direction> { dir };

                Direction rd = avaliableDirections[random.Next(avaliableDirections.Count)];
                if (rd != dir)
                    otherDirCount++;

                current = GetAdjacentLocation(current, rd);
            }
            
            if (matrix[current[0], current[1]] == null)
            {
                matrix[current[0], current[1]] = new Room(roomType + "_" + random.Next(1, 4));
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

    private static List<Direction> GetAvailableDirections(int[] current, Direction mapDir, Room[,] matrix, System.Random r)
    {
        List<Direction> values = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

        if (current[0] == 0 || mapDir == Direction.Right)
            values.Remove(Direction.Left);

        if (current[0] == matrix.GetUpperBound(0) - 1 || mapDir == Direction.Left)
            values.Remove(Direction.Right);

        if (current[1] == 0 || mapDir == Direction.Down)
            values.Remove(Direction.Up);

        if (current[1] == matrix.GetUpperBound(1) - 1 || mapDir == Direction.Up)
            values.Remove(Direction.Down);

        return values;
    }

    private static int[] GetAdjacentLocation(int[] current, Direction dir)
    {
        int[] next = current.Select(i => i).ToArray();
        switch (dir)
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
