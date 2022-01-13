using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int mazesPassed;
    public GameObject player;
    public GameObject key;
    public GameObject MazeExit;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void Update() 
    {
        key = GameObject.FindWithTag("Key");
        MazeExit = GameObject.FindWithTag("EndPoint");

        if((MazeExit != null) && (key != null))
        {
            key.GetComponent<EndP>().endPoint = MazeExit;
            MazeExit.SetActive(false);
        }


        if(player.GetComponent<PlayerHealth>().health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
