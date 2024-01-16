using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class HubReset : PuzzleObject
{
    [SerializeField]
    Hub mapController;
    public enum PuzzleType{sokoban}
    public PuzzleType puzzleType;

    public override void interact(){
        switch (puzzleType){
            case PuzzleType.sokoban:
                bool checkLocation =
                Mathf.Abs(mapController.player.transform.position.x) < 2.5 &&
                -10.5f < mapController.player.transform.position.z &&  mapController.player.transform.position.z < -5.9f &&
                Mathf.Abs(mapController.player.transform.position.y - 1.2f) < 0.04f;

                if(!checkLocation) return;
                mapController.SokobanReset();
                mapController.player.transform.position = new Vector3(-1.2f,1.2f,-6);
                break;
        };
    }
}
}