using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public static bool isPaused =false;

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

   void Resume()
    {
        Debug.Log("Game is Resumed");
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Debug.Log("Game is Paused");
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


  
    void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }

    void LoadMenu()
    {
        Debug.Log("Loading Menu....");
    }




}
