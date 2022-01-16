using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimController;
    public GameObject weapon;
    public int weaponDamage;

    void Start() {
        weapon = this.gameObject;
        weapon.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            StartCoroutine(Attack(0.48f));
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
}
