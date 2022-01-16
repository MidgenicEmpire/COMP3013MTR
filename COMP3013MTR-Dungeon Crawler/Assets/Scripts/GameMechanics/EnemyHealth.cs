using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    public float maxHP;
    public float minHP = 0;
    public float currHP;
    public Animator enemyAnimator;
    public NavMeshAgent enemyNav; 
    public GameObject coinDrop;
    public GameObject enemyDeathLeft;


    void Start(){

       //goldToDrop = Random.Range(5, 10);
        maxHP = 100 + (GameObject.Find("SceneManager").GetComponent<GameManager>().mazesPassed * 10);
        currHP = maxHP;
    }

    void Update() {
        if(currHP > maxHP){
            currHP = maxHP;
        }
    }

    public void TakeDamage(float healthToRemove)
    {
        currHP -= healthToRemove;

        if (currHP == minHP)
        {
            enemyNav.isStopped = true;
            
            enemyAnimator.SetBool("isDead", true);
            enemyAnimator.SetBool("isAlert", false);
            enemyAnimator.SetBool("isWalk", false);
            enemyAnimator.SetBool("isIdle", false);
            enemyAnimator.SetBool("isAttack", false);

           
            Object.Destroy(gameObject, 4f);

            StartCoroutine(PickUp());
            StartCoroutine(DeadPrefab());
        }

        
    }
    IEnumerator PickUp()
    {
        yield return new WaitForSeconds(2.0f);

        yield return Instantiate(coinDrop, new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
      
    }
    IEnumerator DeadPrefab()
    {
        yield return new WaitForSeconds(3.99f);
        
        yield return Instantiate(enemyDeathLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

}
