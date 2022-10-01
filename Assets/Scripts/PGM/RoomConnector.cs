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
        if (collision.gameObject.layer == 1)
        {
            GameObject gameObject = GameObject.Find("MapController");
            if (gameObject != null)
            {
                MapController mc = gameObject.GetComponent<MapController>();
                switch (dir)
                {
                    case Direction.Left:
                        SceneManager.LoadScene(mc.Map.CurrentRoom.LeftRoom.Scene);
                        break;
                    case Direction.Right:
                        SceneManager.LoadScene(mc.Map.CurrentRoom.RightRoom.Scene);
                        break;
                    case Direction.Up:
                        SceneManager.LoadScene(mc.Map.CurrentRoom.TopRoom.Scene);
                        break;
                    case Direction.Down:
                        SceneManager.LoadScene(mc.Map.CurrentRoom.BottomRoom.Scene);
                        break;
                }
            }
        }
    }
}
