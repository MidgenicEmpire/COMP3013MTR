using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public float maxHP;
    public float currHP;
    void Start(){
        maxHP = 100 + (GameObject.Find("SceneManager").GetComponent<GameManager>().mazesPassed * 10);
        currHP = maxHP;
    }

    void Update() {
        if(currHP > maxHP){
            currHP = maxHP;
        }
    }

    public void TakeDamage(float healthToRemove){
        currHP -= healthToRemove;

        if(currHP <= 0){
            Destroy(this.gameObject);
        }
    }
}
