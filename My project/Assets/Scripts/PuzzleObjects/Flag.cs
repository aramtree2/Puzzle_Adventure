using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Flag : PuzzleObject
{
    [SerializeField]
    MapController mapController;

    public override void interact(){
        if(Vector3.Distance(mapController.player.transform.position, transform.position) < 0.7f){ 
            mapController.Clear();
        }
        else{
            IEnumerator travelCoroutine = mapController.player.Travel(transform.position);
            StartCoroutine(travelCoroutine);
        }
    }
}
}