using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    GameObject go;
    Movement movement;
    MeshRenderer meshRenderer;
    Rigidbody rb;
    [SerializeField] float timeToWait = 1f;
    float jumpPower;
    [SerializeField] float jumpRange = 2f;

    // Start is called before the first frame update
    private void Awake() {
        go = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        jumpPower = go.GetComponent<Movement>().jumpPower;
        movement = GetComponent<Movement>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x, jumpRange, 
        transform.position.z);
        
        
    }
}
