using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLoot : MonoBehaviour
{

    public CoinPurse purse;

    private int loot;


    // Start is called before the first frame update
    void Start()
    {
        loot = Random.Range(5, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.TryGetComponent<CoinPurse>(out var gold))
            {
                gold.mazeGold = gold.mazeGold + loot;
            }
            Destroy(gameObject);

            Debug.Log("Reece");

        }
    }
}
