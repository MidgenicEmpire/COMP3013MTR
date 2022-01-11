using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int mazesPassed;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update() 
    {
        if(player.GetComponent<PlayerHealth>().health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
