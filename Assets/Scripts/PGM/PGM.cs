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
    public static Map ProcedurallyGenerateMap(int maxWidth, int maxHeight, int numOfRooms, string roomType, List<GameObject> mobList, List<GameObject> rewardList)
    {
        System.Random random = new System.Random();
        Room[,] array2D = new Room[maxHeight + 1, maxWidth + 1];

        int[] start = new int[] { random.Next(0, maxWidth), random.Next(0, maxHeight) };
        //array2D[start[0], start[1]] = new Room(roomType + "_start");
        array2D[start[0], start[1]] = new Room("placeholder_base");

        int roomCount = 1;
        int[] current = start;
        while (roomCount != numOfRooms)
        {
            List<Direction> avaliableDirections = GetAvailableDirections(current, array2D);
            Direction randomDirection = avaliableDirections[random.Next(avaliableDirections.Count)];
            current = GetAdjacentLocation(current, randomDirection);

            if (array2D[current[0], current[1]] == null)
            {
                if (roomCount < numOfRooms - 1)
                {
                    array2D[current[0], current[1]] = CreateRandomRoom(roomType, mobList, rewardList, random);
                }
                else
                {
                    array2D[current[0], current[1]] = new Room("placeholder_boss_entrance_new");
                }
                roomCount++;
            }
        }

        for (int y = 0; y < array2D.GetUpperBound(0); y++)
        {
            for (int x = 0; x < array2D.GetUpperBound(1); x++)
            {
                if (array2D[y, x] != null)
                {
                    Room room = array2D[y, x];
                    if (x < array2D.GetUpperBound(1) - 1 && array2D[y, x + 1] != null)
                        room.RightRoom = array2D[y, x + 1];

                    if (x > 0 && array2D[y, x - 1] != null)
                        room.LeftRoom = array2D[y, x - 1];

                    if (y < array2D.GetUpperBound(0) - 1 && array2D[y + 1, x] != null)
                        room.BottomRoom = array2D[y + 1, x];

                    if (y > 0 && array2D[y - 1, x] != null)
                        room.TopRoom = array2D[y - 1, x];
                }
            }
        }

        return new Map(array2D[start[0], start[1]], array2D);
    }

    public static IEnumerator LoadMap(MapController mc)
    {
        Room[,] array2D = mc.Map.Array2D;
        List<AsyncOperation> operations = new List<AsyncOperation>();
        for (int y = 0; y < array2D.GetUpperBound(0); y++)
        {
            for (int x = 0; x < array2D.GetUpperBound(1); x++)
            {
                if (array2D[y, x] != null)
                {
                    Room room = array2D[y, x];
                    int operationIndex = SceneManager.sceneCount;
                    room.index = operationIndex;
                    AsyncOperation operation = SceneManager.LoadSceneAsync(room.Scene, LoadSceneMode.Additive);
                    Vector2 pos = new Vector2(x * 35, y * -35);

                    operation.completed += (s) =>
                    {
                        Scene scene = SceneManager.GetSceneAt(operationIndex);
                        GameObject roomObject = scene.GetRootGameObjects()[0];
                        roomObject.transform.position = pos;
                        RoomController roomController = roomObject.GetComponent<RoomController>();
                        roomController.Room = room;
                        roomController.MatchSceneWithRoomProperties();
                        mc.roomControllers.Add(roomController);
                    };

                    operations.Add(operation);
                }
            }
        }
        
        yield return new WaitUntil(() => operations.All(op => op.isDone));
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

    private static Room CreateRandomRoom(string roomType, List<GameObject> enemyList, List<GameObject> rewardList, System.Random random)
    {
        //Room room = new Room(roomType + "_" + random.Next(1, 3));
        Room room = new Room("placeholder_base");
        int numOfMobs = random.Next(4, 7);
        for (int i = 0; i < numOfMobs; i++)
        {
            GameObject mob = enemyList[random.Next(enemyList.Count)];
            room.AddEnemy(mob);
        }
        GameObject reward = rewardList[random.Next(rewardList.Count)];
        room.AddReward(reward);

        return room;
    }
}
