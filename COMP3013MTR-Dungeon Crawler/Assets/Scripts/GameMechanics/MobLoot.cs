using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobLoot : MonoBehaviour
{

    public CoinPurse purse;
    

    private int coinDropAmt;
    public int maxCoin;
    public int minCoin;


    // Start is called before the first frame update
    void Start()
    {
        coinDropAmt = Random.Range(minCoin, maxCoin);
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
                gold.mazeGold = gold.mazeGold + coinDropAmt;
            }
            Destroy(gameObject);

        }
    }
}
