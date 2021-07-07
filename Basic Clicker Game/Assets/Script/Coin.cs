using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    public int totalCoin = 0;
    public TMP_Text coinText;
    CoinPerSecond coinPerSec;

    // Start is called before the first frame update
    void Start()
    {
        
        coinPerSec = GetComponent<CoinPerSecond>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Gold: " + totalCoin;
    }
}