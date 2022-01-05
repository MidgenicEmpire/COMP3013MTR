using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimController;
    public GameObject weapon;

    void Start() {
        weapon = this.gameObject.transform.Find(GameObject.FindGameObjectWithTag("Weapon").transform.name).gameObject;
        weapon.GetComponentInChildren<Collider>().enabled = false;
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
        weapon.GetComponentInChildren<Collider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        weapon.GetComponentInChildren<Collider>().enabled = false;
    }
}
