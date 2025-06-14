using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Attribute to define whether the Game is in Pause state, or not
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Deactivating Pause Menu
        pauseMenuUI.SetActive(false);

        // Unfreezing time
        Time.timeScale = 1f;

        GameIsPaused = false;
    }

    public void Pause()
    {
        // Activating Pause Menu
        pauseMenuUI.SetActive(true);

        // Freezing time
        Time.timeScale = 0f;

        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // Unfreezing time
        Time.timeScale = 1f;

        GameIsPaused = false;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
