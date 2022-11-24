using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// manages the game play loop and contains references to other controllers
public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject playerCamera;
    public MapController mapController;
    public GameObject eventSystem;

    private static string deathScene = "Death_Screen";
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        print("hi");
        SceneManager.activeSceneChanged += ChangedActiveScene;

        player = playerObject.GetComponent<Player>();
        eventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            SceneManager.LoadScene(deathScene);
            Destroy(playerCamera);
            Destroy(mapController.gameObject);
            Destroy(gameObject);
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {

    }
}
