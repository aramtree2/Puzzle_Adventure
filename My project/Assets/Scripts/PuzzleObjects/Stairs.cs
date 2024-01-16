using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Stairs : PuzzleObject
{
    [SerializeField]
    MapController mapController;

    public enum StairType{xUp,xDown,zUp,zDown}
    public StairType stairType;

    public override void interact(){
        float x = 0f;
        float z = 0f;
        switch(stairType){
            case StairType.xUp:
                x = 0.4f;
                break;
            case StairType.xDown:
                x = -0.4f;
                break;
            case StairType.zUp:
                z = 0.4f;
                break;
            case StairType.zDown:
                z = -0.4f;
                break;
        }
        if(Vector3.Distance(mapController.player.transform.position, transform.position + new Vector3(-x,0f,-z)) < 0.04f){
            if(!CheckCanPass(new Vector3(x,0.4f,z))) return;
            if(!CheckCanStep(new Vector3(x,0.4f,z))) return;
            IEnumerator stairCoroutine = mapController.player.Stair(x,0.4f,z);
            StartCoroutine(stairCoroutine);
        }
        else if(Vector3.Distance(mapController.player.transform.position, transform.position + new Vector3(x,0.4f,z)) < 0.04f){
            if(!CheckCanPass(new Vector3(-x,0f,-z))) return;
            if(!CheckCanStep(new Vector3(-x,0f,-z))) return;
            IEnumerator stairCoroutine = mapController.player.Stair(-x,-0.4f,-z);
            StartCoroutine(stairCoroutine);
        }
        else if(Math.Abs(mapController.player.transform.position.y - transform.position.y) < 0.04f){
            IEnumerator travelCoroutine = mapController.player.Travel(transform.position - new Vector3(x,0,z));
            StartCoroutine(travelCoroutine);
        }
        else if(Math.Abs(mapController.player.transform.position.y - transform.position.y - 0.4f) < 0.04f){
            IEnumerator travelCoroutine = mapController.player.Travel(transform.position - new Vector3(-x,0.4f,-z));
            StartCoroutine(travelCoroutine);
        }
        else{
            IEnumerator travelCoroutine = mapController.player.Travel(transform.position);
            StartCoroutine(travelCoroutine);
        }
    }
}
}
