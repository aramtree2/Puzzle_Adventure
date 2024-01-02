using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Teleporter : PuzzleObject
{   
    [SerializeField]
    MapController mapController;
    public Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact(){
        mapController.player.Locate(location);
    }
}
}
