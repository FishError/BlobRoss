using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// manages the game play loop and contains references to other controllers
public class GameController : MonoBehaviour
{
    public MapController mapController;
    public GameObject optionMenu;

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

        if (Keyboard.current.pKey.isPressed && !optionMenu.activeInHierarchy)
        {
            optionMenu.SetActive(true);
        }
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {

    }
}
