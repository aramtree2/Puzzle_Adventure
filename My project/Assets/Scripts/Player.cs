using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace puzzle{
public class Player : MonoBehaviour
{
    public MapController mapController;
    public float speed;
    float hAxis;
    float vAxis;
    bool wDown;
    Vector3 moveVec;
    Animator anim;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");    
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);

        mapController.Click();
    }

    public void Locate(){

    }
    public void Move(){

    }
    public GameObject[] Near(){
        GameObject[] near = new GameObject[8];

        return near;
    }
    public void Travel(Vector3 clickedPosi){

    }
}
}