using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace puzzle{
public class Puzzle1_1 : MapController
{
    [SerializeField]
    IceSlide iceSlide1,iceSlide2,iceSlide3,iceSlide4;

    public void InHole(int stage){
        iceSlide1.Stop();
        iceSlide2.Stop();
        iceSlide3.Stop();
        iceSlide4.Stop();
        clickBlocked = false;
        player.isExternalMoving = false;
        if(stage == 1){
            player.transform.position = new Vector3(-23.6f,1.2f,-5.2f);
        }
        else if(stage == 2){
            player.transform.position = new Vector3(0f,1.6f,-12f);
        }
        else if(stage == 3){
            player.transform.position = new Vector3(-11.6f,2f,-23.2f);
        }
    }

        public override void Clear()
        {
            PlayerPrefs.SetString("1-1","Cleared");
            SceneManager.LoadScene("World1");
        }
    }
}