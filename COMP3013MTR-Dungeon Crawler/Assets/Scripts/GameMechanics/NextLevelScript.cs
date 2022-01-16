using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScript : MonoBehaviour
{

    public Transform nextLevel;
    private GameObject player;
    public GameObject levelToSpawn;
    public GameObject currentLevel;
    

    void Start()
    {
       

    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //this will move the player to the spawn transform of the next level
            player.transform.position = nextLevel.transform.position;

            levelToSpawn.SetActive(true);
            //destroys the previous level in order to better performance
            Destroy(currentLevel);
        }

    }


}
