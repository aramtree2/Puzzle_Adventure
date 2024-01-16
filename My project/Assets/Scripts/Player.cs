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
    public bool isExternalMoving;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        isExternalMoving = false;
    }

    void Update()
    {
        if(!isMoving && !isTravel && !isExternalMoving){
            transform.position = new Vector3(Mathf.Round(transform.position.x* 2.5f) / 2.5f,transform.position.y,Mathf.Round(transform.position.z* 2.5f) / 2.5f);
        }
        transform.rotation = new Quaternion(0f,transform.rotation.y,0f,transform.rotation.w);
    }

    public void Locate(Vector3 location)
    {
        location = new Vector3(Mathf.Round(location.x* 2.5f) / 2.5f,Mathf.Round(location.y* 2.5f) / 2.5f,Mathf.Round(location.z* 2.5f) / 2.5f);
        transform.position = location;
    }

    public void fall(bool on){
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
        if(on){
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            boxCollider.enabled = true;
        }
        else{
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
            boxCollider.enabled = false;
        }
    }

    public IEnumerator Move(float x, float z){
        Vector3  targetLocation = transform.position + new Vector3(x, 0f, z);
        targetLocation.x = Mathf.Round(targetLocation.x* 2.5f) / 2.5f;
        targetLocation.z = Mathf.Round(targetLocation.z* 2.5f) / 2.5f;

        while(true){
            if (Vector3.Distance(transform.position, targetLocation) < 0.04f){
                transform.position = targetLocation;
                isMoving = false;
                anim.SetBool("isMoving", isMoving);
                break;
            }
            else if (Vector3.Distance(transform.position, targetLocation) > 0.7f){
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

    public IEnumerator Stair(float x, float y, float z){
        Vector3 targetLocation1 =  transform.position + new Vector3(x*0.3f, 0f, z*0.3f);
        Vector3 targetLocation2 =  targetLocation1 + new Vector3(x, y, z);
        Vector3 targetLocation3 =  targetLocation2 + new Vector3(x*0.7f, 0f, z*0.7f);
        while(true){
            if (Vector3.Distance(transform.position, targetLocation1) < 0.04f){
                transform.position = targetLocation1;
                break;
            }
            isMoving = true;
            anim.SetBool("isMoving", isMoving);
            transform.LookAt(targetLocation1);
            transform.position += (targetLocation1 - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
        while(true){
            if (Vector3.Distance(transform.position, targetLocation2) < 0.04f){
                transform.position = targetLocation2;
                break;
            }
            transform.position += (targetLocation2 - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
        while(true){
            if (Vector3.Distance(transform.position, targetLocation3) < 0.04f){
                transform.position = targetLocation3;
                isMoving = false;
                anim.SetBool("isMoving", isMoving);
                break;
            }
            transform.position += (targetLocation3 - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator Jump(float h){
        Vector3  targetLocation = transform.position + new Vector3(0f, h, 0f);
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        while(true){
            if (Vector3.Distance(transform.position, targetLocation) < 0.04f){
                transform.position = targetLocation;
                rigidbody.useGravity = true;
                break;
            }
            if(Mathf.Abs(transform.position.x - targetLocation.x) > 0.04f || Mathf.Abs(transform.position.z - targetLocation.z) > 0.04f){
                rigidbody.useGravity = true;
                break;
            }
            RaycastHit hit;
            if(Physics.Raycast(transform.position + new Vector3(0,0.2f,0), new Vector3(0f, 0.4f, 0f), out hit, 0.4f)){
                rigidbody.useGravity = true;
                break;
            }
            rigidbody.useGravity = false;
            transform.position += (targetLocation - transform.position).normalized * speed * Time.deltaTime;
            yield return null;
        }        
    }

    public IEnumerator Travel(Vector3 targetLocation){
        while(Vector3.Distance(transform.position, targetLocation) > 0.04f){
            isTravel = true;
            if(isMoving){
                yield return null;
                continue;
            }
            Vector3 remainVec = targetLocation - transform.position;
            float x = 0f;
            float z = 0f;
            if(remainVec.x > 0.04f) x = 0.4f;
            else if(remainVec.x < -0.04f) x = -0.4f;
            if(remainVec.z > 0.04f) z = 0.4f;
            else if(remainVec.z < -0.04f) z = -0.4f;

            RaycastHit hit;
            int passLayerMask = 1 << LayerMask.NameToLayer("Solid") | 1 << LayerMask.NameToLayer("Obstacle");
            int stepLayerMask = 1 << LayerMask.NameToLayer("Solid");
            bool xBlocked = 
            Physics.Raycast(transform.position + new Vector3(0,0.2f,0), new Vector3(x, 0f, 0f), out hit, 0.4f, passLayerMask) ||
            !Physics.Raycast(transform.position + new Vector3(x,0.2f,0), new Vector3(0, -0.4f, 0f), out hit, 0.4f, stepLayerMask);
            bool zBlocked = 
            Physics.Raycast(transform.position + new Vector3(0,0.2f,0), new Vector3(0f, 0f, z), out hit, 0.4f, passLayerMask) ||
            !Physics.Raycast(transform.position + new Vector3(0,0.2f,z), new Vector3(0f, -0.4f, 0f), out hit, 0.4f, stepLayerMask);
            bool xzBlocked = 
            Physics.Raycast(transform.position + new Vector3(0,0.2f,0), new Vector3(x, 0f, z), out hit, 0.56f, passLayerMask) ||
            !Physics.Raycast(transform.position + new Vector3(x,0.2f,z), new Vector3(0f, -0.4f, 0f), out hit, 0.4f, stepLayerMask);
            
            if(Mathf.Abs(x) > 0.04f && Mathf.Abs(z) > 0.04f){
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
            else if(Mathf.Abs(x) > 0.04f){
                if(xBlocked){
                    break;
                }
                StartCoroutine(Move(x,0));
            }
            else if(Mathf.Abs(z) > 0.04f){
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