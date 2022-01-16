using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        //To allow the player to move when they get into the game
        //movementScript playerMovement = GetComponent<movementScript>();
        //playerMovement.charController = GetComponent<CharacterController>();

        //locks the cursore to the player camera
       Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   public void QuitGame()
    {
        Debug.Log("Game has been Quit");
        Application.Quit();
    }
}
