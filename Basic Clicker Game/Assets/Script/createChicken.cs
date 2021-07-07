using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class createChicken : MonoBehaviour
{
    public TMP_Text chickenCountText;
    int chickenCount;
    public List<Image> sprites;
    public Button clickButton;
    Sprite sprite;
    int i = 0;
    Coin coin;
    int chickenPrice = 75;
    int chickenPower = 1;
    Button btn;
    MouseClick mouseClick;
    public GameObject click;
	void Start () {
        for(int a = 0; a < sprites.Count; a++){
            sprites[a].enabled = false;
        }
        sprite = Resources.Load <Sprite>("chicken");
		btn = clickButton.GetComponent<Button>();
        coin = GameObject.Find("Coin(Bank)").GetComponent<Coin>();
        mouseClick = click.GetComponent<MouseClick>();
        chickenCountText.text = "Count: " + chickenCount;
        btn.onClick.AddListener(addChicken);
    }
    void addChicken(){
        if(coin.totalCoin >= chickenPrice){
            chickenCount++;
            mouseClick.clickPower += chickenPower;
            coin.totalCoin -= chickenPrice;
            Image image = sprites[i];
            image.GetComponent<Image>().sprite = sprite;
            sprites[i].enabled = true;
            i++;
        }
    }
}
