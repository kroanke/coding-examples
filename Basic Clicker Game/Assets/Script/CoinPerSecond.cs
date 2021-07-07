using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinPerSecond : MonoBehaviour
{
    public TMP_Text coinPerSecondText;
    public int coinPerSecond = 1;
    Coin coin;
    float Timer;
    int seconds;
    int compareSeconds = 0;


    void Start()
    {
        // coin = GetComponent<Coin>();
        coin = GameObject.Find("Coin(Bank)").GetComponent<Coin>();

        // coin = FindGameObjectsWithTag("Coin(Bank)").GetComponent<CoinPerSecond>();
        
    }

    void Update()
    {
        coinPerSecondText.text = coinPerSecond + " Gold Per Second";
        Timer += Time.deltaTime;
        seconds = (int)Timer;
        if(seconds == compareSeconds){
            coin.totalCoin += coinPerSecond;
            compareSeconds++;
        }
        
        
    }
}
