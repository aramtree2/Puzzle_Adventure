using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class Puzzle2 : MapController
    {
        [SerializeField] MapController mapController;
        public bool stage2Clear;

        // 1 => blue, 2 => yellow
        public int memoryAnswerKey;
        // blue, 1 3 0 4 2
        // yellow, 3 1 2 0 4
        // player's answer => memoryAnswerArray
        public int[] memoryAnswerArray;
        public int playerInputSequence;

        [SerializeField] GameObject[] memoryBox;
        [SerializeField] GameObject[] inputButton;
        [SerializeField] GameObject totalReset;

        [SerializeField] GameObject substagePortal2_3;

        // reset flag
        [SerializeField] GameObject flag2_3;

        public void Awake()
        {
            stage2Clear = false;
        }

        public override void StartFunction()
        {
            memoryAnswerKey = 0;
            playerInputSequence = 0;
        }

        public override void UpdateFunction()
        {
            if (PlayerPrefs.GetString("Puzzle2_3") == "Cleared")
            {
                substagePortal2_3.SetActive(false);
                totalReset.SetActive(true);
                flag2_3.SetActive(true);
            }
            else
            {
                substagePortal2_3.SetActive(true);
                totalReset.SetActive(false);
                flag2_3.SetActive(false);
            }

            Stage2ClearCheck();

            if (PlayerPrefs.GetString("Puzzle2") == "Cleared")
            {
                flag2_3.SetActive(false);

                for (int index = 0; index < 5; index++)
                {
                    inputButton[index].SetActive(false);
                }    

                if (PlayerPrefs.GetString("Puzzle2Color") == "Blue")
                {
                    for (int index = 0; index < 5; index++)
                    {
                        memoryBox[index].GetComponent<MemoryBox>().ChangeColor(1);
                    }
                }

                if (PlayerPrefs.GetString("Puzzle2Color") == "Yellow")
                {
                    for (int index = 0; index < 5; index++)
                    {
                        memoryBox[index].GetComponent<MemoryBox>().ChangeColor(2);
                    }
                }
            }
            

        }

        private void Stage2ClearCheck()
        {
            switch (memoryAnswerKey)
            {
                case 0 :
                    return;

                case 1 :
                    if (memoryAnswerArray[0] == 1)
                        if (memoryAnswerArray[1] == 3)
                            if (memoryAnswerArray[2] == 0)
                                if (memoryAnswerArray[3] == 4)
                                    if (memoryAnswerArray[4] == 2)
                                    {
                                        stage2Clear = true;
                                        PlayerPrefs.SetString("Puzzle2", "Cleared");
                                        PlayerPrefs.SetString("Puzzle2Color", "Blue");
                                        flag2_3.SetActive(false);
                                        
                                        inputButton[0].SetActive(false);
                                        inputButton[1].SetActive(false);
                                        inputButton[2].SetActive(false);
                                        inputButton[3].SetActive(false);
                                        inputButton[4].SetActive(false);

                                        memoryBox[0].GetComponent<MemoryBox>().ChangeColor(1);
                                        memoryBox[1].GetComponent<MemoryBox>().ChangeColor(1);
                                        memoryBox[2].GetComponent<MemoryBox>().ChangeColor(1);
                                        memoryBox[3].GetComponent<MemoryBox>().ChangeColor(1);
                                        memoryBox[4].GetComponent<MemoryBox>().ChangeColor(1);

                                    }
                    break;

                case 2 :
                    if (memoryAnswerArray[0] == 3)
                        if (memoryAnswerArray[1] == 1)
                            if (memoryAnswerArray[2] == 2)
                                if (memoryAnswerArray[3] == 0)
                                    if (memoryAnswerArray[4] == 4)
                                    {
                                        stage2Clear = true;
                                        PlayerPrefs.SetString("Puzzle2", "Cleared");
                                        PlayerPrefs.SetString("Puzzle2Color", "Yellow");
                                        flag2_3.SetActive(false);

                                        inputButton[0].SetActive(false);
                                        inputButton[1].SetActive(false);
                                        inputButton[2].SetActive(false);
                                        inputButton[3].SetActive(false);
                                        inputButton[4].SetActive(false);

                                        memoryBox[0].GetComponent<MemoryBox>().ChangeColor(2);
                                        memoryBox[1].GetComponent<MemoryBox>().ChangeColor(2);
                                        memoryBox[2].GetComponent<MemoryBox>().ChangeColor(2);
                                        memoryBox[3].GetComponent<MemoryBox>().ChangeColor(2);
                                        memoryBox[4].GetComponent<MemoryBox>().ChangeColor(2);

                                    }
                    break;
            }
        }

        public void SavePlayerInput(int number)
        {
            memoryAnswerArray[playerInputSequence] = inputButton[number].GetComponent<Puzzle2Button>().buttonNumber;
            playerInputSequence++;
        }
    }
}
