using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MouseClick : MonoBehaviour
{
    public TMP_Text coinPerClickText;
    public Button clickButton;
    public int clickPower = 1;
    Coin coin;
    void Start()
    {
        Button btn = clickButton.GetComponent<Button>();
        btn.onClick.AddListener(addGold);
        coin = GameObject.Find("Coin(Bank)").GetComponent<Coin>();
        
        
    }
    private void Update() {
        coinPerClickText.text = clickPower + " Gold Per Click";
    }
    void addGold(){
        coin.totalCoin += clickPower;
    }
}
