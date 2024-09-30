using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Hole : PuzzleObject
{
    [SerializeField]
    MapController mapController;
    public int stage;
    Puzzle1_1 mapController1_1;

    // Start is called before the first frame update
    void Start()
    {
        mapController1_1 = (Puzzle1_1) mapController;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(mapController.player.transform.position, transform.position + new Vector3(0f,0.4f,0f)) < 0.04f){
            mapController1_1.InHole(stage);
        }
    }
}
}