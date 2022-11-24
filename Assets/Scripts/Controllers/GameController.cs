using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// manages the game play loop and contains references to other controllers
public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public BossRoomController bossController;
    public GameObject playerCamera;
    public GameObject mapController;
    public GameObject optionsController;

    private static string deathScene = "Death_Screen";
    private static string winScene = "Win_Screen";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject == null)
        {
            StartCoroutine(WaitDefeatScreen());
        }
    }

    public void LoadDefeatScreen()
    {
        SceneManager.LoadScene(deathScene);
        Destroy(playerCamera);
        Destroy(mapController);
        Destroy(optionsController);
        Destroy(gameObject);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene(winScene);
        Destroy(playerObject);
        Destroy(playerCamera);
        Destroy(mapController);
        Destroy(optionsController);
        Destroy(gameObject);
    }

    public IEnumerator WaitDefeatScreen()
    {
        yield return new WaitForSeconds(1f);
        LoadDefeatScreen();
    }

    public IEnumerator WaitWinScreen()
    {
        yield return new WaitForSeconds(1f);
        LoadWinScreen();
    }
}
