using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// manages the game play loop and contains references to other controllers
public class GameController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject bossObject;
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
        bossController = GameObject.Find("BossRoomController").GetComponent<BossRoomController>();

        if (playerObject == null)
        {
            SceneManager.LoadScene(deathScene);
            Destroy(playerCamera);
            Destroy(mapController);
            Destroy(optionsController);
            Destroy(gameObject);
        }

        if(bossController.isBossDefeated)
        {
            SceneManager.LoadScene(winScene);
            Destroy(playerCamera);
            Destroy(mapController);
            Destroy(optionsController);
            Destroy(gameObject);
        }
    }
}
