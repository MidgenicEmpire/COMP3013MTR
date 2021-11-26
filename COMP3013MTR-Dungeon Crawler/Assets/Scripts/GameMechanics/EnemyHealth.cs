using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int maxHP;
    public int currHP;

    public EnemyHealth(int max)
    {
        this.maxHP = max;
        currHP = maxHP;
    }

    // Update is called once per frame
    public void TakeDamage(int healthToRemove)
    {
        currHP -= healthToRemove;

        if(currHP >= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
