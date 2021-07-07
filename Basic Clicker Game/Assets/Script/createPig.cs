using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class createPig : MonoBehaviour
{
    public TMP_Text pigCountText;
    int pigCount;
    public List<Image> sprites;
    public Button clickButton;
    Sprite sprite;
    Coin coin;
    int i = 0;
    int pigPrice = 15000;
    int pigPower = 2;
    CoinPerSecond coinPerSecond;
	void Start () {
        for(int a = 0; a < sprites.Count; a++){
            sprites[a].enabled = false;
        }
        sprite = Resources.Load <Sprite>("pig");
		Button btn = clickButton.GetComponent<Button>();
        coin = GameObject.Find("Coin(Bank)").GetComponent<Coin>();
        coinPerSecond = GameObject.Find("CoinPerSecond").GetComponent<CoinPerSecond>();
        pigCountText.text = "Count: " + pigCount;
        btn.onClick.AddListener(addPig);
    }
    void addPig(){
        if(coin.totalCoin >= pigPrice && i != 6){
            pigCount++;
            coinPerSecond.coinPerSecond += pigPower;
            coin.totalCoin -= pigPrice;
            Image image = sprites[i];
            image.GetComponent<Image>().sprite = sprite;
            sprites[i].enabled = true;
            i++;
        }
    }
}
