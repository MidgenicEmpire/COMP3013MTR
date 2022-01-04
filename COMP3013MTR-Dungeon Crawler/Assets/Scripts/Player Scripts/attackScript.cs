using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimController;
    public GameObject weapon;

    void Start() {
        weapon = this.gameObject.transform.Find(GameObject.FindGameObjectWithTag("Weapon").transform.name).gameObject;
        weaponAnimController = weapon.GetComponent<Animator>();
        weapon.GetComponentInChildren<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            StartCoroutine(Attack(1f));
        }
    }

    IEnumerator Attack(float attackTime)
    {
        weaponAnimController.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        weapon.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.15f);
        weapon.GetComponent<Collider>().enabled = false;
    }
}
