using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField] private Animator swordAnimController;
    public GameObject sword;

    void Start() {
        sword.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
            StartCoroutine(Attack(1.60f));
        }
    }

    IEnumerator Attack(float attackTime)
    {
        swordAnimController.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        sword.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(0.15f);
        sword.GetComponent<Collider>().enabled = false;
    }
}
