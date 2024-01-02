using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace puzzle{
public class Player : MonoBehaviour
{
    public float speed;

    Animator anim;

    bool isMoving;
    bool isTravel;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if(!isMoving && !isTravel){
            transform.position = new Vector3(Mathf.Round(transform.position.x),transform.position.y,Mathf.Round(transform.position.z));
        }
        transform.rotation = new Quaternion(0f,transform.rotation.y,0f,transform.rotation.w);
    }

    public void Locate(Vector3 location)
    {
        location = new Vector3(Mathf.Round(location.x),Mathf.Round(location.y)+0.5f,Mathf.Round(location.z));
        transform.position = location;
    }

    public IEnumerator Move(float x, float z){
        Vector3  targetLocation = transform.position + new Vector3(x, 0f, z);
        targetLocation.x = Mathf.Round(targetLocation.x);
        targetLocation.z = Mathf.Round(targetLocation.z);

        while(true){
            if (Vector3.Distance(transform.position, targetLocation) < 0.1f){
                transform.position = targetLocation;
                isMoving = false;
                anim.SetBool("isMoving", isMoving);
                break;
            }
            else if (Vector3.Distance(transform.position, targetLocation) > 1.9f){
                isMoving = false;
                anim.SetBool("isMoving", isMoving);
                break;
            }
            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            transform.LookAt(targetLocation);
            transform.position += (targetLocation - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }        
    }

    public IEnumerator Jump(float h){
        Vector3  targetLocation = transform.position + new Vector3(0f, h, 0f);
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        while(true){
            if (Vector3.Distance(transform.position, targetLocation) < 0.1f){
                transform.position = targetLocation;
                rigidbody.useGravity = true;
                break;
            }
            if(Mathf.Abs(transform.position.x - targetLocation.x) > 0.1f || Mathf.Abs(transform.position.z - targetLocation.z) > 0.1f){
                rigidbody.useGravity = true;
                break;
            }
            RaycastHit hit;
            if(Physics.Raycast(transform.position + new Vector3(0,0.5f,0), new Vector3(0f, 1f, 0f), out hit, 1f)){
                rigidbody.useGravity = true;
                break;
            }
            rigidbody.useGravity = false;
            transform.position += (targetLocation - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }        
    }

    public IEnumerator Travel(Vector3 targetLocation){
        while(Vector3.Distance(transform.position, targetLocation) > 0.1f){
            isTravel = true;
            if(isMoving){
                yield return null;
                continue;
            }
            Vector3 remainVec = targetLocation - transform.position;
            float x = 0f;
            float z = 0f;
            if(remainVec.x > 0.1f) x = 1f;
            else if(remainVec.x < -0.1f) x = -1f;
            if(remainVec.z > 0.1f) z = 1f;
            else if(remainVec.z < -0.1f) z = -1f;

            RaycastHit hit;
            bool xBlocked = 
            Physics.Raycast(transform.position + new Vector3(0,0.5f,0), new Vector3(x, 0f, 0f), out hit, 1f) ||
            !Physics.Raycast(transform.position + new Vector3(x,0.5f,0), new Vector3(0, -1f, 0f), out hit, 1f);
            bool zBlocked = 
            Physics.Raycast(transform.position + new Vector3(0,0.5f,0), new Vector3(0f, 0f, z), out hit, 1f) ||
            !Physics.Raycast(transform.position + new Vector3(0,0.5f,z), new Vector3(0f, -1f, 0f), out hit, 1f);
            bool xzBlocked = 
            Physics.Raycast(transform.position + new Vector3(0,0.5f,0), new Vector3(x, 0f, z), out hit, 1.4f) ||
            !Physics.Raycast(transform.position + new Vector3(x,0.5f,z), new Vector3(0f, -1f, 0f), out hit, 1f);
            
            if(Mathf.Abs(x) > 0.1f && Mathf.Abs(z) > 0.1f){
                if(xBlocked || zBlocked || xzBlocked){
                    if(xBlocked && zBlocked){
                        break;
                    }
                    else{
                        if(Mathf.Abs(remainVec.x) > Mathf.Abs(remainVec.z)){
                            if(!xBlocked) StartCoroutine(Move(x,0));
                            else{
                                if(!zBlocked) StartCoroutine(Move(0,z));
                            }
                        }
                        else{
                            if(!zBlocked) StartCoroutine(Move(0,z));
                            else{
                                if(!xBlocked) StartCoroutine(Move(x,0));
                            }
                        }
                    }
                }
                else{
                    StartCoroutine(Move(x,z));
                }
            }
            else if(Mathf.Abs(x) > 0.1f){
                if(xBlocked){
                    break;
                }
                StartCoroutine(Move(x,0));
            }
            else if(Mathf.Abs(z) > 0.1f){
                if(zBlocked){
                    break;
                }
                StartCoroutine(Move(0,z));
            }
            else{
                break;
            }
            yield return null;
        }
        isTravel = false;
    }
}
}