using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [Header("Map Settings")]
    public int maxWidth;
    public int maxHeight;
    public string roomType;

    public GameObject player;

    public Map Map { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        Map = PGM.ProcedurallyGenerateMap(maxWidth, maxHeight, 5, roomType);
        SceneManager.LoadScene(Map.StartRoom.Scene);
        print("left: " + Map.StartRoom.LeftRoom);
        print("top: " + Map.StartRoom.TopRoom);
        print("right: " + Map.StartRoom.RightRoom);
        print("bottom: " + Map.StartRoom.BottomRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        Map.CurrentRoom.MatchSceneToRoomConstraints();
    }
}
