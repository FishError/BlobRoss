using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    private Map map;

    [Header("Map Settings")]
    public int maxWidth;
    public int maxHeight;
    public string roomType;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, 5, roomType);
        SceneManager.LoadScene(map.StartRoom.Scene);
        print("left: " + map.StartRoom.LeftRoom);
        print("top: " + map.StartRoom.TopRoom);
        print("right: " + map.StartRoom.RightRoom);
        print("bottom: " + map.StartRoom.BottomRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        map.StartRoom.MatchSceneToRoomConstraints();
    }
}
