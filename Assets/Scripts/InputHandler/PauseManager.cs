using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private GameObject optionMenu;

    private void Start()
    {
        Time.timeScale = 1;
        optionMenu = GameObject.Find("OptionMenuController");
    }

    private void OnPause(InputValue value)
    {
        if(value.Get<float>() == 1)
        {
            if (Time.timeScale == 1)
            {
                PauseGame();
            }
            else if (Time.timeScale == 0)
            {
                UnpauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        optionMenu.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1f;
        CheckChild();
    }

    private void CheckChild()
    {
        for (int i = 0; i < optionMenu.transform.childCount; i++)
        {;
            if (optionMenu.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                optionMenu.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void OnBackUnPause()
    {
        Time.timeScale = 1;
    }

    public void BackToMainMenu(string scene)
    {
        SceneManager.LoadScene(scene);
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("Camera"));
        Destroy(GameObject.Find("GameController"));
        Destroy(GameObject.Find("MapController"));
        Destroy(GameObject.Find("OptionController"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
