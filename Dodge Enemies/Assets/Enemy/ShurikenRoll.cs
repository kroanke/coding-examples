using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenRoll : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(-34,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        rotateSpeed++;
        // transform.rotation = Quaternion.Euler(-34,rotateSpeed,0);
        transform.Rotate(0,rotateSpeed,0);
    }
}
