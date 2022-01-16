using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointScript : MonoBehaviour
{
    public GameObject sceneManager;

    void OnEnable() {
        sceneManager = GameObject.Find("SceneManager");
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            sceneManager = GameObject.Find("SceneManager");
            sceneManager.GetComponent<GameManager>().mazesPassed++;
            sceneManager.GetComponent<GameManager>().NewMaze();
            Debug.Log(sceneManager.GetComponent<GameManager>().mazesPassed);
        }
    }
}
