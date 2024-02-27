using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class Puzzle2Button : PuzzleObject
    {
        [SerializeField] MapController mapController;

        [SerializeField] GameObject linkedMemoryBox;
        [SerializeField] GameObject pushButton;

        public int buttonNumber;

        public override void interact()
        {
            mapController.GetComponent<Puzzle2>().SavePlayerInput(buttonNumber);
            StartCoroutine(BlinkInteract());
            StartCoroutine(PushInteract());
        }

        private IEnumerator BlinkInteract()
        {
            linkedMemoryBox.GetComponent<MemoryBox>().ChangeColor(mapController.GetComponent<Puzzle2>().memoryAnswerKey);
            yield return new WaitForSeconds(0.3f);
            linkedMemoryBox.GetComponent<MemoryBox>().ChangeColor(0);
        }

        private IEnumerator PushInteract()
        {
            pushButton.transform.position -= new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.15f);
            pushButton.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
}