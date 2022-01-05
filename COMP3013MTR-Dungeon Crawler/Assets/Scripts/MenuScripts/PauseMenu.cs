using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject healthBar;
    public static bool isPaused = false;
    public string MainMenu;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        Debug.Log("Game is Resumed");
        pauseUI.SetActive(false);
        healthBar.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        //This sets where the cursor interacts
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {
        Debug.Log("Game is Paused");
        pauseUI.SetActive(true);
        healthBar.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu....");
        SceneManager.LoadScene(MainMenu);
    }




}
