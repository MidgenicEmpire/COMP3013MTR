using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelGenerator;
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

    public void NewMaze()
    {
        levelGenerator.GetComponent<mazeGeneratorScript>().ClearMaze();
        levelGenerator.GetComponent<mazeGeneratorScript>().currentMaze = levelGenerator.GetComponent<mazeGeneratorScript>().mazesToGenerate[UnityEngine.Random.Range(0, levelGenerator.GetComponent<mazeGeneratorScript>().mazesToGenerate.Length)];
        levelGenerator.GetComponent<mazeGeneratorScript>().GenerateMaze();
    }
}
