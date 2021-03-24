using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Movement : MonoBehaviour
{
    
    public Rigidbody rb;
    
    [SerializeField] public float jumpPower = 6f;
    [SerializeField] bool canJump = true;
    [SerializeField] float xRange = 5.5f;
    [SerializeField] float leftXRange = -5.6f;
    [SerializeField] public float controlSpeed = 15f;
    [SerializeField] public float forwardSpeed = 40f;
    PointPickup jumpPickup;
    public float DelayAmount = 1.5f;
    protected float Timer; 
    public float lastSpeed;
    public float latestSpeed;
    bool pause;
    public TMP_Text pauseText;
    
    private void Awake() {
        
        
    }
    void Start()
    {
        
        
        jumpPickup = GetComponent<PointPickup>();
        
        rb = GetComponent<Rigidbody>();
        
        
        
    }

    public void Update()
    {
        
        if(forwardSpeed != 0){
            //increase the speed of the player
            Timer += Time.deltaTime;
            if(Timer >= DelayAmount){
                Timer = 0f;
                forwardSpeed += 5;
            }
        }
        
        
        float xMovement = Input.GetAxis("Horizontal");

        float xOffset = xMovement * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, leftXRange, xRange);
        
        
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
        // rb.velocity = 40 * Vector3.forward;
        
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(jumpPickup.jumpPoints >= 1 && canJump){
                rb.velocity = jumpPower * transform.up;
                canJump = false;
                jumpPickup.jumpPoints--;
                // this.transform.Translate(Vector3.up * jumpPower);    
            }
        }
        if(gameObject.tag == "Player"){
            transform.localPosition = new Vector3(
                clampedXPos,
                transform.localPosition.y,
                transform.localPosition.z
            );
        }
        
        // if(forwardSpeed == 0){
        //     latestSpeed = lastSpeed;
        // }
        // lastSpeed = forwardSpeed;
        if(Input.GetKeyDown(KeyCode.P)){
            pause = !pause;
            PauseGame();
        }
        
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Plane"){
            canJump = true;
        }
        
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "JumpPad"){
            canJump = false;
            rb.velocity = jumpPower * transform.up;
        }
    }
    void PauseGame(){
        if(pause){
            pauseText.text = ("PAUSED!! " + " PRESS 'P' TO RESUME");
            Time.timeScale = 0;
        }
        else{
            pauseText.text = ("PRESS 'P' TO PAUSE");
            Time.timeScale = 1;
        }
    }
}
