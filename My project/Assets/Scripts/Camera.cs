using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    bool focusTarget;

    void Start(){
        focusTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(focusTarget == true){
            Follow();
        }
    }

    void Follow(){
        transform.position = target.position + offset;
    }
    void Drag(){
        focusTarget = false;
    }
    void Wheel(){

    }
    void Reset(){
        focusTarget = true;
    }
}
}