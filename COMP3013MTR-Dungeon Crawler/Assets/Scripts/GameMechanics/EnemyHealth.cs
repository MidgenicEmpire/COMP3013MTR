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
    int lootLoop = 1;

    //Sound
    


    void Start(){

       //goldToDrop = Random.Range(5, 10);
        //maxHP = 100 + (GameObject.Find("SceneManager").GetComponent<GameManager>().mazesPassed * 10);
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


        if (currHP <= minHP)
        {
            enemyNav.isStopped = true;
            //sets iI to 1 so the for loop can loop once meaning that if the enemy is attacked while down and his health hits below 0 this code doesn't
            //run again and cause a second loot pile to spawn
            
            enemyAnimator.SetBool("isDead", true);
            //Enemy death sound
            gameObject.GetComponent<EnemyAI>().eSound.playSound("eDeath");
            enemyAnimator.SetBool("isAlert", false);
            enemyAnimator.SetBool("isWalk", false);
            enemyAnimator.SetBool("isIdle", false);
            enemyAnimator.SetBool("isAttack", false);

           
            Object.Destroy(gameObject, 3f);

            for (int i = 0; i < lootLoop; i++)
            {
                StartCoroutine(PickUp());
                StartCoroutine(DeadPrefab());

                lootLoop = 0;
            }
         
        }

        
    }

    IEnumerator PickUp()
    {
        yield return new WaitForSeconds(1f);

        yield return Instantiate(coinDrop, new Vector3(gameObject.transform.position.x , gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
      
    }
    IEnumerator DeadPrefab()
    {
        yield return new WaitForSeconds(1f);
        
        yield return Instantiate(enemyDeathLeft, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

}
