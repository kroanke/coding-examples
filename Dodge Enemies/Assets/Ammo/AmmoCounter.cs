using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text attackText;
    public Text healthText;
    public Text jumpText;
    PointPickup points;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        points = player.GetComponent<PointPickup>();
        attackText.text = ("Attack: " + points.attackPoints.ToString());
        healthText.text = (points.healthPoints.ToString() + " ♥");
        jumpText.text = ("Jump: " + points.jumpPoints.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        attackText.text = ("Attack: " + points.attackPoints.ToString());
        healthText.text = (points.healthPoints.ToString() + " ♥");
        jumpText.text = ("Jump: " + points.jumpPoints.ToString());
    }
}
