using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endPointScript : MonoBehaviour
{
    public GameObject levelGenerator;

    void OnEnable() {
        levelGenerator = this.gameObject.transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            Debug.Log("Level should end");
            levelGenerator.GetComponent<mazeGeneratorScript>().ClearMaze();
            levelGenerator.GetComponent<mazeGeneratorScript>().GenerateMaze();
        }
    }
}
