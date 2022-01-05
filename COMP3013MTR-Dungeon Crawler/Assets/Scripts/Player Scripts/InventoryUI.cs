using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    public bool inventorySpace = false;

    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if (inventorySpace)
            {
                InventoryResume();


            }
            else
            {
                InventoryPause();
            }

        }
    }



    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
               
            }
            else
            {
                slots[i].ClearSlot();
                
            }
        }
    }


    void InventoryPause()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        inventorySpace = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void InventoryResume()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        Time.timeScale = 1f;
        inventorySpace = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
