using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace puzzle{
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float zoomSpeed;
    public float zoomMax;
    public float zoomMin;
    public float followSpeed;

    Vector3 focusTarget;
    float wheelInput;
    Vector3 dragPos;

    void Start(){
        focusTarget = target.position;
        StartCoroutine("Reset");
    }

    // Update is called once per frame
    void Update()
    {
        wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if(wheelInput != 0){
            Wheel(wheelInput);
        }

        if(Input.GetMouseButton(2)){
            StartCoroutine("Reset");
        }

        if(Input.GetMouseButtonDown(1)){
            StartCoroutine("Drag");
            StopCoroutine("Reset");
        }
        if(Input.GetMouseButtonUp(1)){
            StopCoroutine("Drag");
        }
        
        Follow();
    }

    void Follow(){
        transform.position = Vector3.Lerp(transform.position, focusTarget + offset + new Vector3(0,0.2f,0), followSpeed);
    }
    IEnumerator Drag(){
        dragPos = Input.mousePosition;
        while(true){
            Vector3 delta = new Vector3(dragPos.x - Input.mousePosition.x,0,dragPos.y - Input.mousePosition.y);
            delta /= 500f;
            delta *= offset.x;
            delta = Quaternion.Euler(0,225,0) * delta;
            focusTarget += delta;
            dragPos = Input.mousePosition;
            yield return null;
        }
    }
    void Wheel(float wheelInput){
        if(wheelInput > 0) {
            offset -= new Vector3(zoomSpeed,zoomSpeed*2,zoomSpeed);
            if(offset.x <= zoomMin) offset = new Vector3(zoomMin,zoomMin*2,zoomMin);
        }
        else if(wheelInput < 0){
            offset += new Vector3(zoomSpeed,zoomSpeed*2,zoomSpeed);
            if(offset.x >= zoomMax) offset = new Vector3(zoomMax,zoomMax*2,zoomMax);
        }
    }
    IEnumerator Reset(){
        while(true){
            focusTarget = target.position;
            yield return null;
        }
    }
}
}