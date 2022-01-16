using UnityEngine.UI;
using UnityEngine;
using System;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public ItemObject item;
    public PlayerHealth health;
    public Button btnEquip;
    public Outline outline;
    public GameObject player;
    public int newhealth;

    public void Start()
    {
        if(icon.sprite == null)
        {
            icon.enabled = false;
        }

       
    }

    public void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void AddItem(ItemObject newItem)
    {

        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void BtnClick()
    {

        Debug.Log(item == null);

        if (item != null)
        {

            if (!outline.enabled) EquipItem();

            else if (outline.enabled) UnequipItem();
        }
        else
        {
            outline.enabled = false;
            Debug.Log("Button works but dont do fuck all");
        }
    }
    public void UnequipItem()
    {

            outline.enabled = false;
            player.GetComponent<PlayerHealth>().health -= item.statHealth;
            player.GetComponent<PlayerHealth>().healthMax -= item.statHealth;


    }
    public void EquipItem()
    {

            outline.enabled = true;
            player.GetComponent<PlayerHealth>().health += item.statHealth;
            player.GetComponent<PlayerHealth>().healthMax += item.statHealth;
        

    }
}
