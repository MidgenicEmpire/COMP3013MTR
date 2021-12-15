using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointScript : MonoBehaviour
{
    public GameObject levelGenerator;
    public GameObject sceneManager;

    void OnEnable() {
        levelGenerator = this.gameObject.transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            levelGenerator.GetComponent<mazeGeneratorScript>().ClearMaze();
            levelGenerator.GetComponent<mazeGeneratorScript>().currentMaze = levelGenerator.GetComponent<mazeGeneratorScript>().mazesToGenerate[UnityEngine.Random.Range(0, levelGenerator.GetComponent<mazeGeneratorScript>().mazesToGenerate.Length)];
            levelGenerator.GetComponent<mazeGeneratorScript>().GenerateMaze();
            
            sceneManager = GameObject.Find("SceneManager");
            sceneManager.GetComponent<GameManager>().mazesPassed++;
            Debug.Log(sceneManager.GetComponent<GameManager>().mazesPassed);
        }
    }
}
