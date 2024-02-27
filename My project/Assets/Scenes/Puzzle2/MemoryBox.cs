using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class MemoryBox : PuzzleObject
    {
        [SerializeField] MapController mapController;

        [SerializeField] GameObject memoryBox;

        public int memoryBoxNumber;

        Renderer memoryRenderer;

        // blue
        Color memoryColor1 = new Color(1, 1, 1, 1);
        // yellow
        Color memoryColor2 = new Color(1, 1, 1, 1);

        Color memoryDefaultColor = new Color(1, 1, 1, 1);

        [SerializeField] bool showColor1;
        [SerializeField] bool showColor2;

        private void Start()
        {
            memoryRenderer = memoryBox.GetComponentInChildren<Renderer>();
            memoryRenderer.material.SetColor("_Color", memoryDefaultColor);
            showColor2 = true;
        }

        private void Update()
        {
            if (PlayerPrefs.GetString("Puzzle2_3") == "Cleared")
                showColor1 = true;

            CheckAvailableColor();
        }

        private void CheckAvailableColor()
        {
            if (showColor1)
                memoryColor1 = new Color(0, 0.416f, 0.655f, 1.0f);
            
            if (showColor2)
                memoryColor2 = new Color(1.0f, 0.8f, 0.01f, 1.0f);
        }

        public IEnumerator ColorSequence()
        {
            switch (memoryBoxNumber)
            {
                case 0 : // - - B Y -
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(1);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(2);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    break;
                
                case 1 : // B Y - - -
                    ChangeColor(1);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(2);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    break;

                case 2 : // - - Y - B
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(2);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(1);
                    yield return new WaitForSeconds(0.5f);
                    break;
                
                case 3 : // Y B - - -
                    ChangeColor(2);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(1);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    break;
                
                case 4 : // - - - B Y
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(0);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(1);
                    yield return new WaitForSeconds(0.5f);
                    ChangeColor(2);
                    yield return new WaitForSeconds(0.5f);
                    break;
            }

            int answerColor = mapController.GetComponent<Puzzle2>().memoryAnswerKey;

            if (PlayerPrefs.GetString("Puzzle2_3") == "Cleared")
            {
                ChangeColor(answerColor);
                yield return new WaitForSeconds(1);
            }
            
            ChangeColor(0); // "turning off"
        }

        public void ChangeColor(int colorNumber)
        {
            switch (colorNumber)
            {
                case 0 :
                    memoryRenderer.material.SetColor("_Color", memoryDefaultColor);
                    break;
                    
                case 1 :
                    memoryRenderer.material.SetColor("_Color", memoryColor1);
                    break;

                case 2 :
                    memoryRenderer.material.SetColor("_Color", memoryColor2);
                    break;
            }
        }
    }
}