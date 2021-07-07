using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class createCow : MonoBehaviour
{
    public TMP_Text cowCountText;
    int cowCount;
    public List<Image> sprites;
    public Button clickButton;
    Sprite sprite;
    Coin coin;
    int i = 0;
    int cowPrice = 100000;
    int cowPower = 3;
    MouseClick mouseClick;
    public GameObject click;
    CoinPerSecond coinPerSecond;
	void Start () {
        for(int a = 0; a < sprites.Count; a++){
            sprites[a].enabled = false;
        }
        sprite = Resources.Load <Sprite>("cow");
		Button btn = clickButton.GetComponent<Button>();
        coin = GameObject.Find("Coin(Bank)").GetComponent<Coin>();
        coinPerSecond = GameObject.Find("CoinPerSecond").GetComponent<CoinPerSecond>();
        mouseClick = click.GetComponent<MouseClick>();
        cowCountText.text = "Count: " + cowCount;
        btn.onClick.AddListener(addCow);
    }
    void addCow(){
        if(coin.totalCoin >= cowPrice && i != 6){
            coinPerSecond.coinPerSecond += cowPower;
            mouseClick.clickPower += cowPower;
            coin.totalCoin -= cowPrice;
            Image image = sprites[i];
            image.GetComponent<Image>().sprite = sprite;
            sprites[i].enabled = true;
            i++;
        }
    }
}
