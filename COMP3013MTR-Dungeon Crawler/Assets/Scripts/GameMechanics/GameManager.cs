using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        PlayerHealth playerhealth = new PlayerHealth(100);

        Debug.Log("Health: " + playerhealth.GetHealth());
        playerhealth.TakeDamage(30);
        Debug.Log("Health: " + playerhealth.GetHealth());
        playerhealth.Heal(30);
        Debug.Log("Health: " + playerhealth.GetHealth());
    }
}
