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

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Weapon" && this.gameObject.tag == "Enemy"){
            StartCoroutine(dealDamagePlayer(0.30f, this.gameObject, other.gameObject.GetComponentInParent<attackScript>().weaponDamage));
        }

        else if(other.gameObject.tag == "EnemyWeapon" && this.gameObject.tag == "Player"){
            StartCoroutine(dealDamageEnemy(1.25f, this.gameObject, other.gameObject.GetComponentInParent<EnemyAI>().enemyWeaponDamage));
        }
    }

    public IEnumerator dealDamagePlayer(float time, GameObject obj, int damageAmount)
    {
        while(true)
        {
            Debug.Log("Enemy hit");
            if(!alreadyHit)
            {
                obj.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(damageAmount);
                alreadyHit = true;
                Debug.Log(this.gameObject.GetComponentInParent<EnemyHealth>().currHP);
            }
            
            yield return new WaitForSeconds(time);
            alreadyHit = false;
            yield break;
        }
    }

    public IEnumerator dealDamageEnemy(float time, GameObject obj, int damageAmount)
    {
        while(true)
        {
            Debug.Log("Player hit");
            if(!alreadyHit)
            {
                Debug.Log("player has not been hit yet");
                obj.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
                alreadyHit = true;
            }
            yield return new WaitForSeconds(time);
            alreadyHit = false;
            yield break;
        }
    }
}
