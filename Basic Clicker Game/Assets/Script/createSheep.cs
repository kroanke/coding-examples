using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class createSheep : MonoBehaviour
{
    public TMP_Text sheepCountText;
    public List<Image> sprites;
    public Button clickButton;
    Sprite sprite;
    Coin coin;
    int i = 0;
    int sheepCount;
    int sheepPrice = 1000;
    int sheepPower = 2;
    MouseClick mouseClick;
    public GameObject click;
	void Start () {
        for(int a = 0; a < sprites.Count; a++){
            sprites[a].enabled = false;
        }
        sprite = Resources.Load <Sprite>("sheep");
		Button btn = clickButton.GetComponent<Button>();
        coin = GameObject.Find("Coin(Bank)").GetComponent<Coin>();
        mouseClick = click.GetComponent<MouseClick>();
        sheepCountText.text = "Count: " + sheepCount;
        btn.onClick.AddListener(addSheep);
    }
    void addSheep(){
        if(coin.totalCoin >= sheepPrice && i != 6){
            sheepCount++;
            mouseClick.clickPower += sheepPower;
            coin.totalCoin -= sheepPrice;
            Image image = sprites[i];
            image.GetComponent<Image>().sprite = sprite;
            sprites[i].enabled = true;
            i++;
        }
    }
}
