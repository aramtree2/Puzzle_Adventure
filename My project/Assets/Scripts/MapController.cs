using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class MapController : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Click(){
        player.Travel();
        // interact(puzzleObject);
    }
    void interact(PuzzleObject puzzleObject){
        puzzleObject.interact();
    }
}
}

