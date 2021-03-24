using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingKunai : MonoBehaviour
{
    public GameObject kunai;
    protected float Timer;
    Rigidbody rb;
    float timeToWait = 1f;
    float timeToKill = 3f;
    PointPickup health;
    public GameObject player;
    EndGame end;
    void Start()
    {
        end = player.GetComponent<EndGame>();
        health = player.GetComponent<PointPickup>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    
    void Update()
    {
        Timer += Time.deltaTime;
        if(Timer >= timeToWait){
            rb.useGravity = true;
        }
        
        
        else if(Time.time >= timeToKill){
            
        }
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            ProcessHit();
            Debug.Log("hit");
        }
    }
    void ProcessHit(){
        health.healthPoints--;
        if(health.healthPoints <= 0){
            end.StartCrashSequence();
            
        }
    }
    
}
