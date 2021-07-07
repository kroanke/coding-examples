using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndGameMovement : MonoBehaviour
{
    
    public Rigidbody rb;
    
  
    
    [SerializeField] public float forwardSpeed = 20f;
    
    
    
    void Start()
    {
        
        
        
        rb = GetComponent<Rigidbody>();
        
        
        
    }

    public void Update()
    {
        
        
        

        
        
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
 
        
  
    }
    
}
