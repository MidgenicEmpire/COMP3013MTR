using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    GameObject healthBarObject;

    void Start() 
    {
        healthBarObject = this.gameObject;
    }

    public void Update()
    {
        healthBarObject.GetComponent<Slider>().value = playerHealth.GetHealthPercent();

    }

    //Updates player health only on event trigger
    private void PlayerHealth_OnHealthChanged(object sender, System.EventArgs e)
    {
        transform.Find("FillContainer").localScale = new Vector3(playerHealth.GetHealthPercent(), 1);
    }
}
