using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public Camera cam5;
    public Camera cam7;
    float Timer;
    void Start()
    {
        
        cam1.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
        cam5.enabled = false;
        cam7.enabled = false;

    }
    void Update(){
        Timer += Time.deltaTime;
        Debug.Log(Timer);
        swapCam();
    }
    void swapCam(){
        if(Timer >= 6.5f){
            cam1.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = false;
            cam7.enabled = false;
        }
        if(Timer >= 12.8f){
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = true;
            cam4.enabled = false;
            cam5.enabled = false;
            cam7.enabled = false;
        }
        if(Timer >= 19.4){
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = true;
            cam5.enabled = false;
            cam7.enabled = false;
        }
        if(Timer >= 22.1){
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = false;
            cam7.enabled = true;
        }
        if(Timer >= 25.7){
            cam1.enabled = false;
            cam2.enabled = false;
            cam3.enabled = false;
            cam4.enabled = false;
            cam5.enabled = true;
            cam7.enabled = false;
        }
        
        
    }
}
