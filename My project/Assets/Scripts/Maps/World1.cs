using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace puzzle{
public class World1 : MapController
{
    [SerializeField]
    GameObject puzzle1_1;
    
    public void Start(){
        if(PlayerPrefs.GetString("1-1") == "Cleared"){
            puzzle1_1.transform.localPosition = new Vector3(0,0,0);
        }
        else{
            puzzle1_1.transform.localPosition = new Vector3(0,100,0);
        }
    }
}
}