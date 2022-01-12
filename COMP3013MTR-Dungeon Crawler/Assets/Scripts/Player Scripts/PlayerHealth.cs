using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    public event EventHandler OnHealthChanged;
    [SerializeField]public int health;
    [SerializeField]private int healthMax = 100;
    //Health bar
    public HealthBarController healthBarHandler;
    void Awake()
    {
        health = healthMax;
        healthBarHandler.playerHealth = this;
    }
public int GetHealth()
    {
        return health;
    }

public float GetHealthPercent()
    {
        return (float)health / healthMax;
    }


    //This ensures that if the player has 0 HP damage will still continue
public void TakeDamage( int damageAmount)
    {
        Debug.Log("Player should lose " + damageAmount);
        health -= damageAmount;
        if (health < 0) health = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }

public void Heal (int healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }


    //This is to test the healthBar
   

}
