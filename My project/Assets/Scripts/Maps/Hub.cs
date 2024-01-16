using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class Hub : MapController
{   
    [SerializeField]
    PushBox sokobanBox1,sokobanBox2,sokobanBox3,sokobanBox4,sokobanBox5;
    [SerializeField]
    HubReset sokobanFlag;
    [SerializeField]
    Portal sokobanPortal;


    public bool sokobanCleared;

    public override void UpdateFunction()
    {
        sokobanCheck();
    }

    public override void Reset()
    {
        SokobanReset();
        player.transform.position = new Vector3(0,0.4f,0);

        sokobanCleared = false;

        if(PlayerPrefs.GetString("HubSokoban") == "Cleared"){
            sokobanCleared = true;
            sokobanPortal.transform.localPosition = new Vector3(0f,0f,0f);
        }
        
        if(!sokobanCleared){
            sokobanPortal.transform.localPosition += new Vector3(100f,100f,0);
        }
    }

    public void SokobanReset(){
        sokobanBox1.transform.localPosition = new Vector3(0,0,0);
        sokobanBox2.transform.localPosition = new Vector3(0,0,0);
        sokobanBox3.transform.localPosition = new Vector3(0,0,0);
        sokobanBox4.transform.localPosition = new Vector3(0,0,0);
        sokobanBox5.transform.localPosition = new Vector3(0,0,0);
    }

    void sokobanCheck(){
        if(sokobanCleared) return;
        RaycastHit hit;
        GameObject boxCheck;
        PushBox pushbox;
        if(!Physics.Raycast(new Vector3(1.6f,1.8f,-8.4f), new Vector3(0, -1f, 0f), out hit, 0.4f)) return;
        boxCheck = hit.transform.gameObject;
        pushbox = boxCheck.GetComponent<PushBox>();
        if(pushbox == null) return;
        if(!Physics.Raycast(new Vector3(2f,1.8f,-9.2f), new Vector3(0, -1f, 0f), out hit, 0.4f)) return;
        boxCheck = hit.transform.gameObject;
        pushbox = boxCheck.GetComponent<PushBox>();
        if(pushbox == null) return;
        if(!Physics.Raycast(new Vector3(0f,1.8f,-9.6f), new Vector3(0, -1f, 0f), out hit, 0.4f)) return;
        boxCheck = hit.transform.gameObject;
        pushbox = boxCheck.GetComponent<PushBox>();
        if(pushbox == null) return;
        if(!Physics.Raycast(new Vector3(-1.2f,1.8f,-10.4f), new Vector3(0, -1f, 0f), out hit, 0.4f)) return;
        boxCheck = hit.transform.gameObject;
        pushbox = boxCheck.GetComponent<PushBox>();
        if(pushbox == null) return;
        if(!Physics.Raycast(new Vector3(-1.6f,1.8f,-9.6f), new Vector3(0, -1f, 0f), out hit, 0.4f)) return;
        boxCheck = hit.transform.gameObject;
        pushbox = boxCheck.GetComponent<PushBox>();
        if(pushbox == null) return;
        sokobanCleared = true;
        sokobanFlag.transform.localPosition += new Vector3(100f,100f,0);
        sokobanPortal.transform.localPosition = new Vector3(0f,0f,0f);
        PlayerPrefs.SetString("HubSokoban","Cleared");
    }
}
}