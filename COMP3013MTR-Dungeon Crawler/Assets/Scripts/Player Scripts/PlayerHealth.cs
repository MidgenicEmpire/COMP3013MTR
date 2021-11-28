using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth
{
    public event EventHandler OnHealthChanged;
    private int health;
    private int healthMax;
    //Health bar
    public Slider healthSlider;
 public PlayerHealth(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
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
