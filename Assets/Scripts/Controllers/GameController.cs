using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// top controller that manages all other controllers
public class GameController : MonoBehaviour
{
    public MapController mapController;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Camera"));
            Destroy(GameObject.Find("GameController"));
            SceneManager.LoadScene(0);
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {

    }
}
