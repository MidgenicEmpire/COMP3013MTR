using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public float maxHP;
    public float currHP;

    void Update() {
        maxHP = this.gameObject.GetComponentInParent<mazeGeneratorScript>().newMaxHP;

        if(currHP > maxHP){
            currHP = maxHP;
        }
    }

    void LateUpdate() {
        currHP = maxHP;
    }

    public void TakeDamage(float healthToRemove){
        currHP -= healthToRemove;

        if(currHP <= 0){
            Destroy(this.gameObject);
        }
    }
}
