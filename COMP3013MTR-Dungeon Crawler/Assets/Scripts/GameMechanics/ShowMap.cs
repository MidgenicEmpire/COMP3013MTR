using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShowMap : MonoBehaviour
{
    public GameObject weapon;
    public GameObject UI;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UI.SetActive(true);
           
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (weapon.activeSelf) 
        {
            UI.SetActive(false);
        }
        else 
        {
            UI.SetActive(true);
        }
    }
}
