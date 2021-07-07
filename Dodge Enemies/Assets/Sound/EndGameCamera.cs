using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCamera : MonoBehaviour
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
        //TODO oyuncu duvara carptiginda yavasladiginda camerayi da yavaslat
        
        // cameraSpeed = movement.forwardSpeed;
        //Move the camera with the same speed and the direction as the Player
        transform.Translate(Vector3.forward * cameraSpeed * Time.deltaTime);
    }
    
}
