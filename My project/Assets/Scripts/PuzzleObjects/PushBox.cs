using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class PushBox : PuzzleObject
{
    [SerializeField]
    MapController mapController;

    public override void interact(){
        if(Vector3.Distance(mapController.player.transform.position, transform.position) < 0.5f){
            IEnumerator moveCoroutine;
            if(Mathf.Abs(mapController.player.transform.position.x - transform.position.x) < 0.04f){
                if(mapController.player.transform.position.z < transform.position.z){
                    if(!CheckCanPass(new Vector3(0f,0f,0.4f))) return;
                    if(!CheckCanStep(new Vector3(0f,0f,0.4f))) return;
                    moveCoroutine = Move(0f,0.4f);
                    StartCoroutine(moveCoroutine);
                }
                else if(mapController.player.transform.position.z > transform.position.z){
                    if(!CheckCanPass(new Vector3(0f,0f,-0.4f))) return;
                    if(!CheckCanStep(new Vector3(0f,0f,-0.4f))) return;
                    moveCoroutine = Move(0f,-0.4f);
                    StartCoroutine(moveCoroutine);
                }
            }
            else if(Mathf.Abs(mapController.player.transform.position.z - transform.position.z) < 0.04f){
                if(mapController.player.transform.position.x < transform.position.x){
                    if(!CheckCanPass(new Vector3(0.4f,0f,0f))) return;
                    if(!CheckCanStep(new Vector3(0.4f,0f,0f))) return;
                    moveCoroutine = Move(0.4f,0f);
                    StartCoroutine(moveCoroutine);
                }
                else if(mapController.player.transform.position.x > transform.position.x){
                    if(!CheckCanPass(new Vector3(-0.4f,0f,0f))) return;
                    if(!CheckCanStep(new Vector3(-0.4f,0f,0f))) return;
                    moveCoroutine = Move(-0.4f,0f);
                    StartCoroutine(moveCoroutine);
                }
            }            
        }
        else{
            IEnumerator travelCoroutine = mapController.player.Travel(transform.position);
            StartCoroutine(travelCoroutine);
        }
    }

    IEnumerator Move(float x, float z){
        Vector3  targetLocation = transform.position + new Vector3(x, 0f, z);
        targetLocation.x = Mathf.Round(targetLocation.x* 2.5f) / 2.5f;
        targetLocation.z = Mathf.Round(targetLocation.z* 2.5f) / 2.5f;

        while(true){
            if (Vector3.Distance(transform.position, targetLocation) < 0.04f){
                transform.position = targetLocation;
                break;
            }
            transform.position += (targetLocation - transform.position).normalized * 2 * Time.deltaTime;
            yield return null;
        }        
    }
}
}