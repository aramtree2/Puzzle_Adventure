using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace puzzle{
public class Portal : PuzzleObject
{
    [SerializeField]
    MapController mapController;

    public string sceneName;
    public override void interact(){
        if(Vector3.Distance(mapController.player.transform.position, transform.position) < 0.7f){ 
            SceneManager.LoadScene(sceneName);         
        }
        else{
            IEnumerator travelCoroutine = mapController.player.Travel(transform.position);
            StartCoroutine(travelCoroutine);
        }
    }
}
}