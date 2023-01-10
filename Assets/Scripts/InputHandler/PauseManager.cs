using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private GameObject pauseMenu;
    public List<GameObject> destroyObjects = new List<GameObject>();

    private void Start()
    {
        Time.timeScale = 1;
        pauseMenu = GameObject.Find("PauseMenuController");
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
        pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1f;
        CheckChild();
    }

    private void CheckChild()
    {
        for (int i = 0; i < pauseMenu.transform.childCount; i++)
        {;
            if (pauseMenu.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                pauseMenu.transform.GetChild(i).gameObject.SetActive(false);
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
        destroyObjects.Add(GameObject.Find("SFXManager"));
        for (int i = 0; i < destroyObjects.Count; i++)
        {
            Destroy(destroyObjects[i]);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
