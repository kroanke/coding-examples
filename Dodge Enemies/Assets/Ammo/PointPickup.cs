using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPickup : MonoBehaviour
{
    public GameObject player;
    public GameObject jumpBoost;
    public GameObject healthBoost;
    public GameObject attackBoost;
    GameObject lightt;
    [SerializeField] public int jumpPoints = 1;
    [SerializeField] public int healthPoints = 1;
    [SerializeField] public int attackPoints = 0;
    Renderer r;
    private void Start() {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "JumpPoint"){
            jumpPoints++;
            jumpBoost.SetActive(false);
            // lightt = GameObject.FindWithTag("JumpPoint");
            // lightt.SetActive(false);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "HealthPoint"){
            healthPoints++;
            healthBoost.SetActive(false);
            // lightt = GameObject.FindWithTag("HealthPoint");
            // lightt.SetActive(false);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "AttackPoint"){
            attackPoints++;
            attackBoost.SetActive(false);
            // lightt = GameObject.FindWithTag("AttackPoint");
            // lightt.SetActive(false);
            Destroy(other.gameObject);
        }
        
    }
}
