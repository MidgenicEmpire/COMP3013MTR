using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPurchase : MonoBehaviour
{
    public ItemObject item;
   
    public void ItemToPurchase()
    {
        
        Inventory.instance.Add(item);

    }


}
