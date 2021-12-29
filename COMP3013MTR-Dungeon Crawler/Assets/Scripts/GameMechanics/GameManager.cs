using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public Transform pfHealthBar;

    private void Start()
    {
        PlayerHealth playerhealth = new PlayerHealth(100);

        //This is to set up the player's health
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        HealthBarController healthBar = healthBarTransform.GetComponent<HealthBarController>();

        healthBar.SetUp(playerhealth);

        Debug.Log("Health: " + playerhealth.GetHealthPercent());
        playerhealth.TakeDamage(30);
        Debug.Log("Health: " + playerhealth.GetHealthPercent());
        playerhealth.Heal(30);
        Debug.Log("Health: " + playerhealth.GetHealth());
    }
}
