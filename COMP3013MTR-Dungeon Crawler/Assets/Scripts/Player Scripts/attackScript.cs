using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimController;
    public GameObject weapon;
    public int weaponDamage;

    //Sound Variables
    public GameObject playerSound;
    public AudioManager pSound;

    //Random Sound
    int attackSound;


    void Start() {
        weapon = this.gameObject;
        weapon.GetComponent<Collider>().enabled = false;
        playerSound = GameObject.FindGameObjectWithTag("Sound");
        pSound = playerSound.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            RandomNumber();
            StartCoroutine(Attack(0.48f));
            if(attackSound == 1)
            {
                
                pSound.playSound("Hit1");
                //FindObjectOfType<AudioManager>().playSound("Hit1");

            } else if (attackSound == 2)
            {
                pSound.playSound("Hit2");
                //FindObjectOfType<AudioManager>().playSound("Hit2");
            } else if(attackSound == 3)
            {
                pSound.playSound("Hit3");
                //FindObjectOfType<AudioManager>().playSound("Hit3");
            }
        }
    }

    IEnumerator Attack(float attackTime)
    {
        weaponAnimController.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        weapon.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        weapon.GetComponent<Collider>().enabled = false;
    }

    public void RandomNumber()
    {
        attackSound = Random.Range(1, 4);
    }

}
