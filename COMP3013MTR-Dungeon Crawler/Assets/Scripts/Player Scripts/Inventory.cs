using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 30;

   

    public List<ItemObject> items = new List<ItemObject>();

    private void Update()
    {
      
    }
    public bool Add(ItemObject item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(ItemObject item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }


}
