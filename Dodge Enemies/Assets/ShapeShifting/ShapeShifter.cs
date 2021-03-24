using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeShifter : MonoBehaviour
{
    public Mesh sphere;
    public Mesh capsule;
    public Mesh cube;
    private string shape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShapeShift(){

        switch(shape){
            case "sphere":
                GetComponent<MeshFilter>().mesh = sphere;
                break;
            case "capsule":
                GetComponent<MeshFilter>().mesh = capsule;
                break;
            case "cube":
                GetComponent<MeshFilter>().mesh = cube;
                break;
        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sphere"){
            shape = "sphere";
            ShapeShift();
        }
        else if(other.gameObject.tag == "Capsule"){
            shape = "capsule";
            ShapeShift();
        }
        else if(other.gameObject.tag == "Cube"){
            shape = "cube";
            ShapeShift();
        }
    }
}
