using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    public float maxHP;
    public float currHP;
    public Animator enemyAnimator;
    public NavMeshAgent enemyNav;
    
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

        if(currHP == 0){
            enemyNav.isStopped = true;
            enemyAnimator.SetBool("isDead", true);
            enemyAnimator.SetBool("isAlert", false);
            enemyAnimator.SetBool("isWalk", false);
            enemyAnimator.SetBool("isIdle", false);
            enemyAnimator.SetBool("isAttack", false);
            
            Object.Destroy(gameObject, 5f);
        }
    }
}
