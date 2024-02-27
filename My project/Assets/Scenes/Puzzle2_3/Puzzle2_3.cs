using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class Puzzle2_3 : MapController
    {
        public bool stage2_3_1Clear;
        public bool stage2_3_2Clear;
        public bool stage2_3_3Clear;
        public bool subStage2_3Clear;

        // stage 3 answer : 54 12 15 23 51?

        // stairs
        [SerializeField] GameObject stairs1;
        [SerializeField] GameObject stairs2;

        [SerializeField] GameObject portal1;
        [SerializeField] GameObject portal2;

        // reset flags
        [SerializeField] GameObject flag1;
        [SerializeField] GameObject flag2;
        [SerializeField] GameObject flag3;

        // toggle box
        // stage 1
        public GameObject tBox1;
        public GameObject tBox2;
        public GameObject tBox3;
        public GameObject tBox4;
        public GameObject tBox5;
        public GameObject tBox6;
        public GameObject tBox7;
        public GameObject tBox8;
        public GameObject tBox9;

        // stage 2
        public GameObject tBox10;
        public GameObject tBox11;
        public GameObject tBox12;
        public GameObject tBox13;
        public GameObject tBox14;
        public GameObject tBox15;
        public GameObject tBox16;
        public GameObject tBox17;
        public GameObject tBox18;
        public GameObject tBox19;
        public GameObject tBox20;
        public GameObject tBox21;
        public GameObject tBox22;

        // stage 3
        public GameObject tBox111;
        public GameObject tBox112;
        public GameObject tBox113;
        public GameObject tBox114;
        public GameObject tBox115;
        public GameObject tBox121;
        public GameObject tBox122;
        public GameObject tBox123;
        public GameObject tBox124;
        public GameObject tBox125;
        public GameObject tBox131;
        public GameObject tBox132;
        public GameObject tBox133;
        public GameObject tBox134;
        public GameObject tBox135;
        public GameObject tBox141;
        public GameObject tBox142;
        public GameObject tBox143;
        public GameObject tBox144;
        public GameObject tBox145;
        public GameObject tBox151;
        public GameObject tBox152;
        public GameObject tBox153;
        public GameObject tBox154;
        public GameObject tBox155;

        public void Awake()
        {
            subStage2_3Clear = false;
            stage2_3_1Clear = false;
            stage2_3_2Clear = false;
            stage2_3_3Clear = false;
        }

        public override void UpdateFunction()
        {
            StageClearCheck2_3();
        }

        public void Stage2_3_1Reset()
        {
            tBox1.GetComponent<ToggleBox>().isActivated = false;
            tBox2.GetComponent<ToggleBox>().isActivated = false;
            tBox3.GetComponent<ToggleBox>().isActivated = false;
            tBox4.GetComponent<ToggleBox>().isActivated = false;
            tBox5.GetComponent<ToggleBox>().isActivated = true;
            tBox6.GetComponent<ToggleBox>().isActivated = false;
            tBox7.GetComponent<ToggleBox>().isActivated = false;
            tBox8.GetComponent<ToggleBox>().isActivated = false;
            tBox9.GetComponent<ToggleBox>().isActivated = false;
        }

        public void Stage2_3_2Reset()
        {
            tBox10.GetComponent<ToggleBox>().isActivated = false;
            tBox11.GetComponent<ToggleBox>().isActivated = false;
            tBox12.GetComponent<ToggleBox>().isActivated = false;
            tBox13.GetComponent<ToggleBox>().isActivated = false;
            tBox14.GetComponent<ToggleBox>().isActivated = false;
            tBox15.GetComponent<ToggleBox>().isActivated = false;
            tBox16.GetComponent<ToggleBox>().isActivated = true;
            tBox17.GetComponent<ToggleBox>().isActivated = false;
            tBox18.GetComponent<ToggleBox>().isActivated = false;
            tBox19.GetComponent<ToggleBox>().isActivated = false;
            tBox20.GetComponent<ToggleBox>().isActivated = false;
            tBox21.GetComponent<ToggleBox>().isActivated = false;
            tBox22.GetComponent<ToggleBox>().isActivated = false;
        }

        public void Stage2_3_3Reset()
        {
            tBox111.GetComponent<ToggleBox>().isActivated = false;
            tBox112.GetComponent<ToggleBox>().isActivated = false;
            tBox113.GetComponent<ToggleBox>().isActivated = false;
            tBox114.GetComponent<ToggleBox>().isActivated = false;
            tBox115.GetComponent<ToggleBox>().isActivated = false;
            tBox121.GetComponent<ToggleBox>().isActivated = true;
            tBox122.GetComponent<ToggleBox>().isActivated = true;
            tBox123.GetComponent<ToggleBox>().isActivated = true;
            tBox124.GetComponent<ToggleBox>().isActivated = false;
            tBox125.GetComponent<ToggleBox>().isActivated = false;
            tBox131.GetComponent<ToggleBox>().isActivated = false;
            tBox132.GetComponent<ToggleBox>().isActivated = false;
            tBox133.GetComponent<ToggleBox>().isActivated = false;
            tBox134.GetComponent<ToggleBox>().isActivated = true;
            tBox135.GetComponent<ToggleBox>().isActivated = true;
            tBox141.GetComponent<ToggleBox>().isActivated = true;
            tBox142.GetComponent<ToggleBox>().isActivated = true;
            tBox143.GetComponent<ToggleBox>().isActivated = true;
            tBox144.GetComponent<ToggleBox>().isActivated = false;
            tBox145.GetComponent<ToggleBox>().isActivated = false;
            tBox151.GetComponent<ToggleBox>().isActivated = false;
            tBox152.GetComponent<ToggleBox>().isActivated = false;
            tBox153.GetComponent<ToggleBox>().isActivated = false;
            tBox154.GetComponent<ToggleBox>().isActivated = false;
            tBox155.GetComponent<ToggleBox>().isActivated = false;
        }

        private void StageClearCheck2_3()
        {
            if (tBox1.GetComponent<ToggleBox>().isActivated
             && tBox2.GetComponent<ToggleBox>().isActivated
             && tBox3.GetComponent<ToggleBox>().isActivated
             && tBox4.GetComponent<ToggleBox>().isActivated
             && tBox5.GetComponent<ToggleBox>().isActivated
             && tBox6.GetComponent<ToggleBox>().isActivated
             && tBox7.GetComponent<ToggleBox>().isActivated
             && tBox8.GetComponent<ToggleBox>().isActivated
             && tBox9.GetComponent<ToggleBox>().isActivated)
            {
                tBox1.GetComponent<ToggleBox>().toggleAbility = false;
                tBox2.GetComponent<ToggleBox>().toggleAbility = false;
                tBox3.GetComponent<ToggleBox>().toggleAbility = false;
                tBox4.GetComponent<ToggleBox>().toggleAbility = false;
                tBox5.GetComponent<ToggleBox>().toggleAbility = false;
                tBox6.GetComponent<ToggleBox>().toggleAbility = false;
                tBox7.GetComponent<ToggleBox>().toggleAbility = false;
                tBox8.GetComponent<ToggleBox>().toggleAbility = false;
                tBox9.GetComponent<ToggleBox>().toggleAbility = false;

                stage2_3_1Clear = true;
                stairs1.SetActive(true);
                flag1.SetActive(false);
            }

            if (tBox10.GetComponent<ToggleBox>().isActivated
             && tBox11.GetComponent<ToggleBox>().isActivated
             && tBox12.GetComponent<ToggleBox>().isActivated
             && tBox13.GetComponent<ToggleBox>().isActivated
             && tBox14.GetComponent<ToggleBox>().isActivated
             && tBox15.GetComponent<ToggleBox>().isActivated
             && tBox16.GetComponent<ToggleBox>().isActivated
             && tBox17.GetComponent<ToggleBox>().isActivated
             && tBox18.GetComponent<ToggleBox>().isActivated
             && tBox19.GetComponent<ToggleBox>().isActivated
             && tBox20.GetComponent<ToggleBox>().isActivated
             && tBox21.GetComponent<ToggleBox>().isActivated
             && tBox22.GetComponent<ToggleBox>().isActivated)
            {
                tBox10.GetComponent<ToggleBox>().toggleAbility = false;
                tBox11.GetComponent<ToggleBox>().toggleAbility = false;
                tBox12.GetComponent<ToggleBox>().toggleAbility = false;
                tBox13.GetComponent<ToggleBox>().toggleAbility = false;
                tBox14.GetComponent<ToggleBox>().toggleAbility = false;
                tBox15.GetComponent<ToggleBox>().toggleAbility = false;
                tBox16.GetComponent<ToggleBox>().toggleAbility = false;
                tBox17.GetComponent<ToggleBox>().toggleAbility = false;
                tBox18.GetComponent<ToggleBox>().toggleAbility = false;
                tBox19.GetComponent<ToggleBox>().toggleAbility = false;
                tBox20.GetComponent<ToggleBox>().toggleAbility = false;
                tBox21.GetComponent<ToggleBox>().toggleAbility = false;
                tBox22.GetComponent<ToggleBox>().toggleAbility = false;

                stage2_3_2Clear = true;
                stairs2.SetActive(true);
                flag2.SetActive(false);
            }

            if (tBox111.GetComponent<ToggleBox>().isActivated
              && tBox112.GetComponent<ToggleBox>().isActivated
              && tBox113.GetComponent<ToggleBox>().isActivated
              && tBox114.GetComponent<ToggleBox>().isActivated
              && tBox115.GetComponent<ToggleBox>().isActivated
              && tBox121.GetComponent<ToggleBox>().isActivated
              && tBox122.GetComponent<ToggleBox>().isActivated
              && tBox123.GetComponent<ToggleBox>().isActivated
              && tBox124.GetComponent<ToggleBox>().isActivated
              && tBox125.GetComponent<ToggleBox>().isActivated
              && tBox131.GetComponent<ToggleBox>().isActivated
              && tBox132.GetComponent<ToggleBox>().isActivated
              && tBox133.GetComponent<ToggleBox>().isActivated
              && tBox134.GetComponent<ToggleBox>().isActivated
              && tBox135.GetComponent<ToggleBox>().isActivated
              && tBox141.GetComponent<ToggleBox>().isActivated
              && tBox142.GetComponent<ToggleBox>().isActivated
              && tBox143.GetComponent<ToggleBox>().isActivated
              && tBox144.GetComponent<ToggleBox>().isActivated
              && tBox145.GetComponent<ToggleBox>().isActivated
              && tBox151.GetComponent<ToggleBox>().isActivated
              && tBox152.GetComponent<ToggleBox>().isActivated
              && tBox153.GetComponent<ToggleBox>().isActivated
              && tBox154.GetComponent<ToggleBox>().isActivated
              && tBox155.GetComponent<ToggleBox>().isActivated)
            {
                tBox111.GetComponent<ToggleBox>().toggleAbility = false;
                tBox112.GetComponent<ToggleBox>().toggleAbility = false;
                tBox113.GetComponent<ToggleBox>().toggleAbility = false;
                tBox114.GetComponent<ToggleBox>().toggleAbility = false;
                tBox115.GetComponent<ToggleBox>().toggleAbility = false;
                tBox121.GetComponent<ToggleBox>().toggleAbility = false;
                tBox122.GetComponent<ToggleBox>().toggleAbility = false;
                tBox123.GetComponent<ToggleBox>().toggleAbility = false;
                tBox124.GetComponent<ToggleBox>().toggleAbility = false;
                tBox125.GetComponent<ToggleBox>().toggleAbility = false;
                tBox131.GetComponent<ToggleBox>().toggleAbility = false;
                tBox132.GetComponent<ToggleBox>().toggleAbility = false;
                tBox133.GetComponent<ToggleBox>().toggleAbility = false;
                tBox134.GetComponent<ToggleBox>().toggleAbility = false;
                tBox135.GetComponent<ToggleBox>().toggleAbility = false;
                tBox141.GetComponent<ToggleBox>().toggleAbility = false;
                tBox142.GetComponent<ToggleBox>().toggleAbility = false;
                tBox143.GetComponent<ToggleBox>().toggleAbility = false;
                tBox144.GetComponent<ToggleBox>().toggleAbility = false;
                tBox145.GetComponent<ToggleBox>().toggleAbility = false;
                tBox151.GetComponent<ToggleBox>().toggleAbility = false;
                tBox152.GetComponent<ToggleBox>().toggleAbility = false;
                tBox153.GetComponent<ToggleBox>().toggleAbility = false;
                tBox154.GetComponent<ToggleBox>().toggleAbility = false;
                tBox155.GetComponent<ToggleBox>().toggleAbility = false;
 
                stage2_3_2Clear = true;
                subStage2_3Clear = true;
                PlayerPrefs.SetString("Puzzle2_3", "Cleared");
                flag3.SetActive(false);
                portal2.SetActive(true);
            }
             
        }

        public void ToggleNearby(int boxNumber)
        {
            switch (boxNumber)
            {
                case 1 :
                    tBox1.GetComponent<ToggleBox>().ToggleActivate();
                    tBox2.GetComponent<ToggleBox>().ToggleActivate();
                    tBox4.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 2 :
                    tBox1.GetComponent<ToggleBox>().ToggleActivate();
                    tBox2.GetComponent<ToggleBox>().ToggleActivate();
                    tBox3.GetComponent<ToggleBox>().ToggleActivate();
                    tBox4.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox6.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 3 :
                    tBox2.GetComponent<ToggleBox>().ToggleActivate();
                    tBox3.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox6.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 4 :
                    tBox1.GetComponent<ToggleBox>().ToggleActivate();
                    tBox2.GetComponent<ToggleBox>().ToggleActivate();
                    tBox4.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox7.GetComponent<ToggleBox>().ToggleActivate();
                    tBox8.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 5 :
                    tBox1.GetComponent<ToggleBox>().ToggleActivate();
                    tBox2.GetComponent<ToggleBox>().ToggleActivate();
                    tBox3.GetComponent<ToggleBox>().ToggleActivate();
                    tBox4.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox6.GetComponent<ToggleBox>().ToggleActivate();
                    tBox7.GetComponent<ToggleBox>().ToggleActivate();
                    tBox8.GetComponent<ToggleBox>().ToggleActivate();
                    tBox9.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 6 :
                    tBox2.GetComponent<ToggleBox>().ToggleActivate();
                    tBox3.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox6.GetComponent<ToggleBox>().ToggleActivate();
                    tBox8.GetComponent<ToggleBox>().ToggleActivate();
                    tBox9.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 7 :
                    tBox4.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox7.GetComponent<ToggleBox>().ToggleActivate();
                    tBox8.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 8 :
                    tBox4.GetComponent<ToggleBox>().ToggleActivate();
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox6.GetComponent<ToggleBox>().ToggleActivate();
                    tBox7.GetComponent<ToggleBox>().ToggleActivate();
                    tBox8.GetComponent<ToggleBox>().ToggleActivate();
                    tBox9.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 9 :
                    tBox5.GetComponent<ToggleBox>().ToggleActivate();
                    tBox6.GetComponent<ToggleBox>().ToggleActivate();
                    tBox8.GetComponent<ToggleBox>().ToggleActivate();
                    tBox9.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                // ------------------------------------------------------ 2nd puzzle

                case 10 :
                    tBox10.GetComponent<ToggleBox>().ToggleActivate();
                    tBox11.GetComponent<ToggleBox>().ToggleActivate();
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox13.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 11 :
                    tBox10.GetComponent<ToggleBox>().ToggleActivate();
                    tBox11.GetComponent<ToggleBox>().ToggleActivate();
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox14.GetComponent<ToggleBox>().ToggleActivate();
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 12 :
                    tBox10.GetComponent<ToggleBox>().ToggleActivate();
                    tBox11.GetComponent<ToggleBox>().ToggleActivate();
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox13.GetComponent<ToggleBox>().ToggleActivate();
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 13 :
                    tBox10.GetComponent<ToggleBox>().ToggleActivate();
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox13.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    tBox18.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 14 :
                    tBox11.GetComponent<ToggleBox>().ToggleActivate();
                    tBox14.GetComponent<ToggleBox>().ToggleActivate();
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox19.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 15 :
                    tBox11.GetComponent<ToggleBox>().ToggleActivate();
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox14.GetComponent<ToggleBox>().ToggleActivate();
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox19.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 16 :
                    tBox11.GetComponent<ToggleBox>().ToggleActivate();
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox13.GetComponent<ToggleBox>().ToggleActivate();
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    tBox19.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    tBox21.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 17 :
                    tBox12.GetComponent<ToggleBox>().ToggleActivate();
                    tBox13.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    tBox18.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    tBox21.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 18 :
                    tBox13.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    tBox18.GetComponent<ToggleBox>().ToggleActivate();
                    tBox21.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 19 :
                    tBox14.GetComponent<ToggleBox>().ToggleActivate();
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox19.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    tBox22.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 20 :
                    tBox15.GetComponent<ToggleBox>().ToggleActivate();
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    tBox19.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    tBox21.GetComponent<ToggleBox>().ToggleActivate();
                    tBox22.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 21 :
                    tBox16.GetComponent<ToggleBox>().ToggleActivate();
                    tBox17.GetComponent<ToggleBox>().ToggleActivate();
                    tBox18.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    tBox21.GetComponent<ToggleBox>().ToggleActivate();
                    tBox22.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 22 :
                    tBox19.GetComponent<ToggleBox>().ToggleActivate();
                    tBox20.GetComponent<ToggleBox>().ToggleActivate();
                    tBox21.GetComponent<ToggleBox>().ToggleActivate();
                    tBox22.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                // -------------------------------------------------------------------- 3rd puzzle

                case 111 :
                    tBox111.GetComponent<ToggleBox>().ToggleActivate();
                    tBox112.GetComponent<ToggleBox>().ToggleActivate();
                    tBox121.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 112 :
                    tBox111.GetComponent<ToggleBox>().ToggleActivate();
                    tBox112.GetComponent<ToggleBox>().ToggleActivate();
                    tBox113.GetComponent<ToggleBox>().ToggleActivate();
                    tBox121.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 113 :
                    tBox112.GetComponent<ToggleBox>().ToggleActivate();
                    tBox113.GetComponent<ToggleBox>().ToggleActivate();
                    tBox114.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 114 : 
                    tBox113.GetComponent<ToggleBox>().ToggleActivate();
                    tBox114.GetComponent<ToggleBox>().ToggleActivate();
                    tBox115.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox125.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 115 : 
                    tBox114.GetComponent<ToggleBox>().ToggleActivate();
                    tBox115.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox125.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 121 : 
                    tBox111.GetComponent<ToggleBox>().ToggleActivate();
                    tBox112.GetComponent<ToggleBox>().ToggleActivate();
                    tBox121.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox131.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 122 :
                    tBox111.GetComponent<ToggleBox>().ToggleActivate();
                    tBox112.GetComponent<ToggleBox>().ToggleActivate();
                    tBox113.GetComponent<ToggleBox>().ToggleActivate();
                    tBox121.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox131.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 123 : 
                    tBox112.GetComponent<ToggleBox>().ToggleActivate();
                    tBox113.GetComponent<ToggleBox>().ToggleActivate();
                    tBox114.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 124 :
                    tBox113.GetComponent<ToggleBox>().ToggleActivate();
                    tBox114.GetComponent<ToggleBox>().ToggleActivate();
                    tBox115.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox125.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox135.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 125 :
                    tBox114.GetComponent<ToggleBox>().ToggleActivate();
                    tBox115.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox125.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox135.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 131 :
                    tBox121.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox131.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox141.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 132 : 
                    tBox121.GetComponent<ToggleBox>().ToggleActivate();
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox131.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox141.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 133 :
                    tBox122.GetComponent<ToggleBox>().ToggleActivate();
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 134 : 
                    tBox123.GetComponent<ToggleBox>().ToggleActivate();
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox125.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox135.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox145.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 135 : 
                    tBox124.GetComponent<ToggleBox>().ToggleActivate();
                    tBox125.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox135.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox145.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 141 :
                    tBox131.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox141.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox151.GetComponent<ToggleBox>().ToggleActivate();
                    tBox152.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 142 :
                    tBox131.GetComponent<ToggleBox>().ToggleActivate();
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox141.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox151.GetComponent<ToggleBox>().ToggleActivate();
                    tBox152.GetComponent<ToggleBox>().ToggleActivate();
                    tBox153.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 143 :
                    tBox132.GetComponent<ToggleBox>().ToggleActivate();
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox152.GetComponent<ToggleBox>().ToggleActivate();
                    tBox153.GetComponent<ToggleBox>().ToggleActivate();
                    tBox154.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 144 :
                    tBox133.GetComponent<ToggleBox>().ToggleActivate();
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox135.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox145.GetComponent<ToggleBox>().ToggleActivate();
                    tBox153.GetComponent<ToggleBox>().ToggleActivate();
                    tBox154.GetComponent<ToggleBox>().ToggleActivate();
                    tBox155.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 145 :
                    tBox134.GetComponent<ToggleBox>().ToggleActivate();
                    tBox135.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox145.GetComponent<ToggleBox>().ToggleActivate();
                    tBox154.GetComponent<ToggleBox>().ToggleActivate();
                    tBox155.GetComponent<ToggleBox>().ToggleActivate();
                    break;

                case 151 :
                    tBox141.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox151.GetComponent<ToggleBox>().ToggleActivate();
                    tBox152.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 152 :
                    tBox141.GetComponent<ToggleBox>().ToggleActivate();
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox151.GetComponent<ToggleBox>().ToggleActivate();
                    tBox152.GetComponent<ToggleBox>().ToggleActivate();
                    tBox153.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 153 :
                    tBox142.GetComponent<ToggleBox>().ToggleActivate();
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox152.GetComponent<ToggleBox>().ToggleActivate();
                    tBox153.GetComponent<ToggleBox>().ToggleActivate();
                    tBox154.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 154 :
                    tBox143.GetComponent<ToggleBox>().ToggleActivate();
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox145.GetComponent<ToggleBox>().ToggleActivate();
                    tBox153.GetComponent<ToggleBox>().ToggleActivate();
                    tBox154.GetComponent<ToggleBox>().ToggleActivate();
                    tBox155.GetComponent<ToggleBox>().ToggleActivate();
                    break;
                
                case 155 :
                    tBox144.GetComponent<ToggleBox>().ToggleActivate();
                    tBox145.GetComponent<ToggleBox>().ToggleActivate();
                    tBox154.GetComponent<ToggleBox>().ToggleActivate();
                    tBox155.GetComponent<ToggleBox>().ToggleActivate();
                    break;

            }
        }
}
}