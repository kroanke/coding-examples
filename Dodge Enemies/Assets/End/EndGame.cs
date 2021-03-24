using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    PointPickup pointPickup;
    Obstacle obstacle;
    public GameObject player;
    public GameObject cam;
    GameObject enemy;
    Movement movement;
    cameraHandler cameraHandler;
    protected float Timer;
    public int level = 1;
    bool isTransitioning = false;
    private void Start() {
        pointPickup = player.GetComponent<PointPickup>();
        obstacle = player.GetComponent<Obstacle>();
        movement = player.GetComponent<Movement>();
        cameraHandler = player.GetComponent<cameraHandler>();
        
    }
    private void Update() {
        
        if(movement.forwardSpeed == 0){
            Timer += Time.deltaTime;
            if(Timer >= 2f){
                Time.timeScale = 0;
            }
            
        }
        
        // if(player.transform.position.z >= 440f){
        //     Time.timeScale = 0;
                
        // }    
        
        

       
    }
    
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Enemy"){
            pointPickup.healthPoints = 0;
            StartCrashSequence();
            
            
            
        }
        else if(other.gameObject.tag == "Obstacle" && pointPickup.attackPoints < obstacle.health5){
            movement.forwardSpeed = 0;
            movement.controlSpeed = 0;
            Invoke("StartCrashSequence", 1f);
            
        }
        else if(other.gameObject.tag == "Portal"){
            StartSuccessSequence();
        }

        
    }
    private void OnCollisionEnter(Collision other) {
        // if(isTransitioning){return;}
        if(other.gameObject.tag == "End"){
            if(level == 1){
                levelLoadDelay = 2f;
            }
            else if (level == 2){
                levelLoadDelay = 3f;
            }
            Invoke("StartSuccessSequence", levelLoadDelay);
        }
        else if(other.gameObject.tag == "Portal"){
            StartSuccessSequence();
        }
        
    }
    public void StartSuccessSequence(){
        movement.forwardSpeed = 0;
        Debug.Log("a");
        Invoke("LoadNextLevel", 0);
    }

    public void StartCrashSequence(){
        Debug.Log("b");
        isTransitioning = true;
        movement.forwardSpeed = 0;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 0);
    }

    int LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        level++;
        Debug.Log(level);
        return nextSceneIndex;
    }
    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    
   
        
    
}
