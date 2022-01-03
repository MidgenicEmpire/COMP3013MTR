using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject statPage;
    public GameObject lootPage;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenStatShop()
    {
        statPage.SetActive(true);
        lootPage.SetActive(false);
    }
    public void OpenLootPage()
    {
        statPage.SetActive(false);
        lootPage.SetActive(true);
    }
    public void ExitShop()
    {
        shop.SetActive(false);
        statPage.SetActive(false);
        lootPage.SetActive(false);

    }
    
}
