using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class JumpPad : PuzzleObject
{
    [SerializeField]
    MapController mapController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void interact(){
        StartCoroutine(mapController.player.Jump(1f));
    }
}
}

