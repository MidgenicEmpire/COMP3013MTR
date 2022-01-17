using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    public bool alreadyHit;
    // Start is called before the first frame update

    // Player Damage Sounds
    int playerHurt;
    public GameObject playerSound;
    public AudioManager pSound;

    //Enemy Damage Sounds
    public GameObject enemySound;
    public AudioManager eSound;
    int enemyHurt;

    void Start()
    {
        alreadyHit = false;
        //Player hurt Sounds
        playerSound = GameObject.FindGameObjectWithTag("Sound");
        pSound = playerSound.GetComponent<AudioManager>();

        //Enemy Hurt Sounds
        enemySound = GameObject.FindGameObjectWithTag("eSound");
        eSound = enemySound.GetComponent<AudioManager>();
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

                RandomNumber();
                if (enemyHurt == 1)
                {
                    Debug.Log("Enemy is getting smashed in da face");
                    eSound.playSound("eHurt1");
                }
                else if (enemyHurt == 2)
                {
                    eSound.playSound("eHurt2");
                }
                else if (enemyHurt == 3)
                {
                    eSound.playSound("eHurt3");
                }


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

                RandomNumber();
                if (playerHurt == 1)
                {
                    
                    pSound.playSound("Hurt1");
      
                } else if(playerHurt == 2)
                {
                    pSound.playSound("Hurt2");
                }
                else if(playerHurt == 3)
                {
                    pSound.playSound("Hurt3");
                }

            }
            yield return new WaitForSeconds(time);
            alreadyHit = false;
            yield break;
        }
    }


    public void RandomNumber()
    {
        //Needed to be specific from the random fucntion as it was said to be ambigous
        playerHurt = Random.Range(1, 3);
        enemyHurt = Random.Range(1, 3);
    }




}
