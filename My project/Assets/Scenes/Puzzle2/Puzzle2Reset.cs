using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace puzzle
{
    public class Puzzle2Reset : PuzzleObject
    {
        [SerializeField] MapController mapController;

        [SerializeField] GameObject[] memoryBoxArray;
        [SerializeField] GameObject[] inputButtonArray;

        private void Awake()
        {
            mapController.GetComponent<Puzzle2>().memoryAnswerKey = 0;
        }

        public override void interact()
        {
            mapController.GetComponent<Puzzle2>().playerInputSequence = 0;

            mapController.GetComponent<Puzzle2>().memoryAnswerKey = (int)Random.Range(1, 3);
            Debug.Log(mapController.GetComponent<Puzzle2>().memoryAnswerKey);

            for (int index = 0; index < 5; index++)
                StartCoroutine(memoryBoxArray[index].GetComponent<MemoryBox>().ColorSequence());
        }
    }
}