using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenHit : MonoBehaviour
{
    int shurikenDamage = 1;
    PointPickup health;
    public GameObject player;
    EndGame end;
    void Start()
    {
        end = player.GetComponent<EndGame>();
        health = player.GetComponent<PointPickup>();
    }

    private void OnParticleCollision(GameObject other) {
        if(other.gameObject.tag == "Player"){
            ProcessHit();
        
        }
        
    }
    void ProcessHit(){
        health.healthPoints--;
        if(health.healthPoints <= 0){
            end.StartCrashSequence();
            
        }
    }
}
