using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class Puzzle2_3Reset : PuzzleObject
    {
        [SerializeField] MapController mapController;

        // stage number
        [SerializeField] int resetReference;

        public override void interact()
        {
            switch (resetReference)
            {
                case 1 :
                    mapController.GetComponent<Puzzle2_3>().Stage2_3_1Reset();
                    break;
                    
                case 2 :
                    mapController.GetComponent<Puzzle2_3>().Stage2_3_2Reset();
                    break;
                    
                case 3 :
                    mapController.GetComponent<Puzzle2_3>().Stage2_3_3Reset();
                    break;
            }
        }
    }
}
