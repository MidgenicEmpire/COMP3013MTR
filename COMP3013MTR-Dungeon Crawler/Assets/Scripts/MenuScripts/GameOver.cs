using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    void Update() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Start is called before the first frame update
    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        SceneManager.LoadScene("MainGame");
    }

    // Update is called once per frame
    public void ToMainMenu()
    {
        Debug.Log("Going to main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Debug.Log("Quitting application");
        Application.Quit();
    }
}
