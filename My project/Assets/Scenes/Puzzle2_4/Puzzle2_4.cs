using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class Puzzle2_4 : MapController
    {
        public bool subStage2_4Clear;

        public bool linkMode;
        public int linkModeColor;

        public void Awake()
        {
            subStage2_4Clear = false;
        }
    }
}
