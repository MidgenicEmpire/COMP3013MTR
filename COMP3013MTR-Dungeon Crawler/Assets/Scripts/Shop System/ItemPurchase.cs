using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchase : MonoBehaviour
{
    public ItemObject item;
    public AudioSource purchaseComplete;


    public void ItemToPurchase()
    {
        Inventory.instance.Add(item);
        purchaseComplete.Play();
    }
}
