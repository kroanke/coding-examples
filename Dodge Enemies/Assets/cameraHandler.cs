using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHandler : MonoBehaviour
{
    Movement movement;
    public GameObject player;
    // public GameObject playerObj;
    // Vector3 cameraOffset;
    protected float Timer; 
    
    public float cameraSpeed;
    

    private void Start() {
        
        movement = player.GetComponent<Movement>();
        
        

    }
    void Update() {
        cameraSpeed = movement.forwardSpeed;
        Timer += Time.deltaTime;
        if(Timer >= movement.DelayAmount){
            Timer = 0f;
            cameraSpeed += 5;
        }
        // cameraSpeed = movement.forwardSpeed;
        //Move the camera with the same speed and the direction as the Player
        transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
    }
    
}
