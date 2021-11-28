using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    private PlayerHealth playerHealth;
    GameObject healthBarObject;


    public void SetUp(PlayerHealth playerHealth)
    {
        this.playerHealth = playerHealth;

        playerHealth.OnHealthChanged += PlayerHealth_OnHealthChanged;
    }

    //Updates player health only on event trigger
    private void PlayerHealth_OnHealthChanged(object sendder, System.EventArgs e)
    {
        transform.Find("FillContainer").localScale = new Vector3(playerHealth.GetHealthPercent(), 1);
    }

    
}
