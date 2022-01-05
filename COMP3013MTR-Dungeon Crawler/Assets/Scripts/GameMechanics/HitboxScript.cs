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
        if(other.gameObject.tag == "Weapon"){
            Debug.Log("Weapon detected!");
            StartCoroutine(dealDamage(0.30f, this.transform.parent.gameObject));
        }
    }

    public IEnumerator dealDamage(float time, GameObject obj)
    {
        while(true)
        {
            if(obj.tag == "Enemy")
            {
                Debug.Log("Enemy hit");
                if(!alreadyHit)
                {
                    obj.GetComponent<EnemyHealth>().TakeDamage(25);
                    alreadyHit = true;
                    Debug.Log(obj.GetComponent<EnemyHealth>().currHP);
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
                    obj.transform.Find(GameObject.FindGameObjectWithTag("MainCamera").transform.name).GetComponent<CameraShake>();
                    obj.GetComponent<PlayerHealth>().TakeDamage(25);
                    alreadyHit = true;
                }
                yield return new WaitForSeconds(time);
                alreadyHit = false;
                yield break;
            }
        }
    }
}
