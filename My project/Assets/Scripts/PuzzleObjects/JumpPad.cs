using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class JumpPad : PuzzleObject
{
    [SerializeField]
    MapController mapController;
    public override void interact(){
        StartCoroutine(mapController.player.Jump(0.4f));
    }
}
}

