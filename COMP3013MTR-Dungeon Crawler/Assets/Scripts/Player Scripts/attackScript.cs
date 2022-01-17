using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimController;
    public GameObject weapon;
    public int weaponDamage = 25;

    //Sound Variables
    //private int aSound;

    //Attacking Sound
    //public AudioSource hit1;
    //public AudioSource hit2;
    //public AudioSource hit3;

    void Start() {
        weapon = this.gameObject.transform.Find(GameObject.FindGameObjectWithTag("Weapon").transform.name).gameObject;
        weapon.GetComponentInChildren<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            StartCoroutine(Attack(0.48f));
            //Attack Sound Logic
            //if(aSound == 1)
            //{
            //    hit1.Play();

            //} else if(aSound == 2)
            //{
            //    hit2.Play();

            //} else
            //{
            //    hit3.Play();
            //}

        }
    }

    IEnumerator Attack(float attackTime)
    {
        weaponAnimController.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        weapon.GetComponentInChildren<Collider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        weapon.GetComponentInChildren<Collider>().enabled = false;
    }

    //void RandomNum()
    //{
    //    aSound = Random.Range(1, 4);
    //}


}
