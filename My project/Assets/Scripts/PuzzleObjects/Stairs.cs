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
            IEnumerator stairCoroutine = mapController.player.Stair(x,0.4f,z);
            StartCoroutine(stairCoroutine);
        }
        else if(Vector3.Distance(mapController.player.transform.position, transform.position + new Vector3(x,0.4f,z)) < 0.04f){
            IEnumerator stairCoroutine = mapController.player.Stair(-x,-0.4f,-z);
            StartCoroutine(stairCoroutine);
        }        
    }
}
}
