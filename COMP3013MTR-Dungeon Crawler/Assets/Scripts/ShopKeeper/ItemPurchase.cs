using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchase : MonoBehaviour
{
    public ItemObject item;

    private GameObject player;
    private GameObject weapon;

    public int healthStatIncreaseInteger = 10;
    public int weaponDamageStatIncreaseInteger = 5;
    public float speedStatIncreaseInteger = 1.0f;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.FindGameObjectWithTag("Weapon");
    }
    public void ItemToPurchase()
    {
        Inventory.instance.Add(item);
    }
    public void PriceList()
    {

    }
    public void statPurchaseHealth()
    {
       

        if(player.TryGetComponent<PlayerHealth>(out var health))
        {
            health.healthMax = health.healthMax + healthStatIncreaseInteger;
            health.health = health.health + healthStatIncreaseInteger;
        }
            
    }
    public void statDamageIncrease()
    {
       

        if(weapon.TryGetComponent<attackScript>(out var damage))
        {
            damage.weaponDamage = damage.weaponDamage + weaponDamageStatIncreaseInteger;
        }
    }
    public void statSpeedIncrease()
    {
    

        if(player.TryGetComponent<movementScript>(out var RunSpeed))
        {
            RunSpeed.runSpeed = RunSpeed.runSpeed + speedStatIncreaseInteger;
        }
        if (player.TryGetComponent<movementScript>(out var walkSpeed))
        {
            walkSpeed.walkSpeed = walkSpeed.walkSpeed + speedStatIncreaseInteger;
        }

    }


    
}
