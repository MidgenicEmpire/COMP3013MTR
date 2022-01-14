using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinPurse : MonoBehaviour
{
    public int mazeGold = 0;

    public Text CoinText;

    void Update()
    {
        // Debug.Log(mazeGold);
        CoinText.text = (mazeGold.ToString());

    }
    private void Start()
    {
        CoinText.GetComponent<Text>();

       // mazeGold = 0;
    }
    public int addMazeGold(int gold2add)
    {

        mazeGold = mazeGold + gold2add;

        return mazeGold;

    }
}
