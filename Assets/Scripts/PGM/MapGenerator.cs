using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum Direction
{
    Left,
    Right,
    Up,
    Down
}

public class MapGenerator : MonoBehaviour
{
    private System.Random random;
    private Room[,] matrix;
    private int[] startLocation;
    private int[] endLocation;
    private Direction dir;

    public int matrixWidth;
    public int matrixHeight;
    public string[] roomTypes;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        matrix = new Room[matrixWidth, matrixHeight];
        SetRandomStartAndEndLocation();
        print("start: " + startLocation[0] + ", " + startLocation[1]);
        print("end: " + endLocation[0] + ", " + endLocation[1]);
        GetRandomPath(startLocation, endLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetRandomStartAndEndLocation()
    {
        Array values = typeof(Direction).GetEnumValues();
        dir = (Direction)values.GetValue(random.Next(values.Length));

        switch (dir)
        {
            case Direction.Right:
                startLocation = new int[] { 0, random.Next(0, matrixHeight - 1) };
                endLocation = new int[] { matrixWidth - 1, random.Next(0, matrixHeight - 1) };
                break;
            case Direction.Left:
                startLocation = new int[] { matrixWidth - 1, random.Next(0, matrixHeight - 1) };
                endLocation = new int[] { 0, random.Next(0, matrixHeight - 1) };
                break;
            case Direction.Down:
                startLocation = new int[] { random.Next(0, matrixWidth - 1), 0 };
                endLocation = new int[] { random.Next(0, matrixWidth - 1), matrixHeight - 1 };
                break;
            case Direction.Up:
                startLocation = new int[] { random.Next(0, matrixWidth - 1), matrixHeight - 1 };
                endLocation = new int[] { random.Next(0, matrixWidth - 1), 0 };
                break;
        }
    }

    private void GetRandomPath(int[] start, int[] end)
    {
        matrix[start[0], start[1]] = new Room(roomTypes[0] + random.Next(1, 4));
        int[] current = start;
        int count = 0;
        while (!(current[0] == end[0] && current[1] == end[1]))
        {
            current = GetNextRoomLocation(current);
            if (current == null)
            {
                matrix[current[0], current[1]] = new Room(roomTypes[0] + random.Next(1, 4));
            }
            print(current[0] + ", " + current[1]);
            if (count > 20)
                break;
            count++;
        }
    }

    private int[] GetNextRoomLocation(int[] current)
    {
        List<Direction> values = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();

        if (current[0] == 0 || dir == Direction.Right)
            values.Remove(Direction.Left);

        if (current[0] == matrixWidth - 1 || dir == Direction.Left)
            values.Remove(Direction.Right);

        if (current[1] == 0 || dir == Direction.Down)
            values.Remove(Direction.Up);

        if (current[1] == matrixHeight - 1 || dir == Direction.Up)
            values.Remove(Direction.Down);

        int[] next = current.Select(i => i).ToArray();
        switch (values[random.Next(values.Count)])
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

    private void ApplyRoomConstraints()
    {

    }
}
