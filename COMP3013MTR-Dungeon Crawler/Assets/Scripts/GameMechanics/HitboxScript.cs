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
        if(other.gameObject.tag == "Sword" && alreadyHit == false){
            alreadyHit = true;
            if(this.gameObject.tag == "Player")
            {
                this.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);
            }

            else if(this.gameObject.tag == "Enemy")
            {
                this.gameObject.GetComponent<EnemyHealth>().TakeDamage(25);
            }
        }
    }
}
