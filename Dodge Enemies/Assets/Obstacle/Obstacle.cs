using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    PointPickup attackPoint;
    [SerializeField] public int health5 = 2;
    public GameObject player;
    public GameObject wall;
    Rigidbody rb;
    Movement movement;
    cameraHandler cameraSpeed;
    public GameObject cam;
    MeshRenderer mesh;
    void Start()
    {
        mesh = wall.GetComponent<MeshRenderer>();

        cameraSpeed  = GetComponent<cameraHandler>();
        movement = GetComponent<Movement>();
        //duvara carpinca olmuyorsa ve attacki yetiyorsa yavaslicak ama duvar kirilicak
        attackPoint = player.GetComponent<PointPickup>();
        
    }

   
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Obstacle"){
            if(attackPoint.attackPoints >= health5){
                Debug.Log("a");
                mesh.enabled = false;
                movement.forwardSpeed /= 2;
                attackPoint.healthPoints = attackPoint.healthPoints - health5;
                
            }
        }
    }
    
}
