using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Reset : PuzzleObject
{
    [SerializeField]
    MapController mapController;

    public override void interact(){
        mapController.Reset();
    }
}
}