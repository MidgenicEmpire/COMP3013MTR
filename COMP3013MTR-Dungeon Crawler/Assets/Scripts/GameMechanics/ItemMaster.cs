using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaster : ScriptableObject
{
    //Universal variables
    public string ID;
    public string itemName;
    public string value;
    public bool isEpic;
    public bool canSell;
    public bool canBuy;
    public string itemEffect;
    public GameObject itemModel;


    public void Use()
    {
        //the use of an individual item
    }

    public void Buy()
    {
        //Check current gold amount
        //Add item into the inventory only if player can afford
        //deduct the current gold

    }


    public void Sell()
    {
        //Should check if merchant has gold
        //Will sell if merchant has enough gold
    }

}
