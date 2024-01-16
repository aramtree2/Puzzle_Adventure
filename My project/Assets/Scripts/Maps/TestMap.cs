using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class TestMap : MapController
{
    [SerializeField]
    PushBox box1;

    public override void Reset()
    {
        player.transform.position = new Vector3(3.6f,0.4f,-6f);
        player.transform.LookAt(player.transform.position + new Vector3(0,0,1));
        box1.transform.localPosition = new Vector3(0,0,0);
    }
    public override void Clear()
    {
        Debug.Log("test map clear");
    }
}
}
