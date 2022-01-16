using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPurchase : MonoBehaviour
{
    public ItemObject item;

    private GameObject player;
    private GameObject weapon;
    public int goldToSpend;
    public AudioSource purchaseComplete;
    public AudioSource noMoney;
   
    private void Start()
    {

    }
    private void Update()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        goldToSpend = player.GetComponent<CoinPurse>().mazeGold;

    }
    public void ItemToPurchase()
    {
        if (goldToSpend < item.ItemCost)
        {
            Debug.Log("You have no money, peasant");
            noMoney.Play();
        }
        else
        {
            if (item.isLoot == true)
            {
                Inventory.instance.Add(item);
                purchaseComplete.Play();
                goldToSpend -= item.ItemCost;
                player.GetComponent<CoinPurse>().mazeGold = goldToSpend;
                GetComponentInParent<MerchantNpc>().coinPurse.text = goldToSpend.ToString();

            } else if (item.isStat == true)
            {
                statPurchaseHealth();
                statDamageIncrease();
                statSpeedIncrease();
                purchaseComplete.Play();
                goldToSpend -= item.ItemCost;
                player.GetComponent<CoinPurse>().mazeGold = goldToSpend;
                GetComponentInParent<MerchantNpc>().coinPurse.text = goldToSpend.ToString();

            }
            else
            {
                Debug.Log("Couldn't find item stat");
            }


        }
    }
    public void PriceList()
    {

    }
    public void statPurchaseHealth()
    {
   
            if (player.TryGetComponent<PlayerHealth>(out var health))
            {
                health.healthMax = health.healthMax + item.statHealth;
                health.health = health.health + item.statHealth;
                
            
        }
    }
    public void statDamageIncrease()
    {
     

        if (weapon.TryGetComponent<attackScript>(out var damage))
        {
            damage.weaponDamage = damage.weaponDamage + item.statDamage;
        }
    }
    public void statSpeedIncrease()
    {
    

        if(player.TryGetComponent<movementScript>(out var RunSpeed))
        {
            RunSpeed.runSpeed = RunSpeed.runSpeed + item.statSpeed;
        }
        if (player.TryGetComponent<movementScript>(out var walkSpeed))
        {
            walkSpeed.walkSpeed = walkSpeed.walkSpeed + item.statSpeed;
        }

    }


    
}
