using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class TotalResetPuzzle2 : PuzzleObject
    {
        [SerializeField] GameObject[] memoryBox;

        public override void interact()
        {
            PlayerPrefs.DeleteKey("Puzzle2");
            PlayerPrefs.DeleteKey("Puzzle2Color");
            PlayerPrefs.DeleteKey("Puzzle2_3");

            for (int index = 0; index < 5; index++)
            {
                memoryBox[index].GetComponent<MemoryBox>().ChangeColor(0);
            }
        }
    }
}