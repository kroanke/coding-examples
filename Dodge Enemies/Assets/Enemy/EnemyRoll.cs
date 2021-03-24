using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoll : MonoBehaviour
{
    MeshRenderer rend;
    Rigidbody rigidBody;
    
    
    void Start()
    {
        // renderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();

        
        
        rigidBody.useGravity = false;
        

    }

    void Update()
    {
        
        
        
    }
}
