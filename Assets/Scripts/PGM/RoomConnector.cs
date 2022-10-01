using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomConnector : MonoBehaviour
{
    public Direction dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToConnectRoom(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            GameObject gameObject = GameObject.Find("MapController");
            if (gameObject != null)
            {
                MapController mc = gameObject.GetComponent<MapController>();
                switch (dir)
                {
                    case Direction.Left:
                        mc.previousRoomDir = Direction.Right;
                        mc.Map.CurrentRoom = mc.Map.CurrentRoom.LeftRoom;
                        break;
                    case Direction.Right:
                        mc.previousRoomDir = Direction.Left;
                        mc.Map.CurrentRoom = mc.Map.CurrentRoom.RightRoom;
                        break;
                    case Direction.Up:
                        mc.previousRoomDir = Direction.Down;
                        mc.Map.CurrentRoom = mc.Map.CurrentRoom.TopRoom;
                        break;
                    case Direction.Down:
                        mc.previousRoomDir = Direction.Up;
                        mc.Map.CurrentRoom = mc.Map.CurrentRoom.BottomRoom;
                        break;
                }
                SceneManager.LoadScene(mc.Map.CurrentRoom.Scene);
            }
        }
    }
}
