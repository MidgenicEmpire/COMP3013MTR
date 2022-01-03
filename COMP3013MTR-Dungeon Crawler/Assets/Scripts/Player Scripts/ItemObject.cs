using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Items", menuName = "Items")]
public class ItemObject : ScriptableObject
{
    //item name
    public string ItemName = "New Item";
    //add damage if it's loot

    public Sprite icon = null;

    public int ItemDamage = 0;

    //cost of the item from the shop
    public int ItemCost = 0;

    //item stats
    //add stat if the item is stats not loot
    public int statHealth = 0;
    public int statDamage = 0;
    public int statBlock = 0;
    public int statSpeed = 0;

    //check for loots or stats 
    public bool isLoot = false;
    public bool isStat = false;
    
}
