using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public bool alreadyHit;


    // Start is called before the first frame update
    void Start()
    {
        alreadyHit = false;
    }

    //This gets the collider from the player sword 
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sword"){
            Debug.Log("Sword detected!");
            StartCoroutine(dealDamage(0.30f, this.gameObject));
        }
    }

    IEnumerator dealDamage(float time, GameObject obj)
    {
        while(true)
        {
            if(obj.tag == "Enemy")
            {
                Debug.Log("Enemy hit");
                if(!alreadyHit)
                {
                    this.gameObject.GetComponent<EnemyHealth>().TakeDamage(25);
                    alreadyHit = true;
                    Debug.Log(this.gameObject.GetComponent<EnemyHealth>().currHP);
                }
                
                yield return new WaitForSeconds(time);
                alreadyHit = false;
                yield break;
            }

            else if(obj.tag == "Player")
            {
                Debug.Log("Player hit");
                if(!alreadyHit)
                {                   
                    yield return new WaitForSeconds(time);
                    this.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);
                    alreadyHit = true;
                }
                yield return new WaitForSeconds(time);
                alreadyHit = false;
                yield break;
            }
        }
    }
}
