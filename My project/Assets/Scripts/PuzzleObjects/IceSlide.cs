using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class IceSlide : PuzzleObject
{
    [SerializeField]
    MapController mapController;

    public enum Direction{xPos,xNev,zPos,zNev}
    public Direction dir;

    float x;
    float z;
    bool isSliding;

    public void Start(){
        x = 0f;
        z = 0f;
        switch(dir){
            case Direction.xPos:
                x = 0.4f;
                break;
            case Direction.xNev:
                x = -0.4f;
                break;
            case Direction.zPos:
                z = 0.4f;
                break;
            case Direction.zNev:
                z = -0.4f;
                break;
        }
    }

    public void Update(){
        Vector3 playerLoc = mapController.player.transform.position;
        int rockLayerMask = 1 << LayerMask.NameToLayer("Obstacle");
        int iceLayerMask = 1 << LayerMask.NameToLayer("Decoration");
        RaycastHit hit;
        bool checkRock = Physics.Raycast(playerLoc + new Vector3(0f, 0.2f, 0f), new Vector3(x, 0f, z), out hit, 0.4f, rockLayerMask);
        bool checkIce = Physics.Raycast(playerLoc + new Vector3(x, 0.2f, z), new Vector3(0f, -1f, 0f), out hit, 0.4f, iceLayerMask);
        if(!checkRock && checkIce && !mapController.clickBlocked){
            transform.position = playerLoc + new Vector3(x, 0f, z);
        }
        else{
            transform.position = new Vector3(0,100f,0);
        }
    }
    public override void interact()
    {
        mapController.clickBlocked = true;
        StartCoroutine(Slide());
    }

    public IEnumerator Slide(){
        isSliding = false;
        while(true){
            if(isSliding){
                yield return null;
                continue;
            }
            Vector3 playerLoc = mapController.player.transform.position;
            int rockLayerMask = 1 << LayerMask.NameToLayer("Obstacle");
            int iceLayerMask = 1 << LayerMask.NameToLayer("Decoration");
            RaycastHit hit;
            bool checkRock = Physics.Raycast(playerLoc + new Vector3(0f, 0.2f, 0f), new Vector3(x, 0f, z), out hit, 0.4f, rockLayerMask);
            bool checkIce = Physics.Raycast(playerLoc + new Vector3(x, 0.2f, z), new Vector3(0f, -1f, 0f), out hit, 0.4f, iceLayerMask);
            if(!checkRock && checkIce){
                StartCoroutine(Move(x,z));
            }
            else{
                break;
            }
            yield return null;
        }
        mapController.clickBlocked = false;
    }
    public IEnumerator Move(float mx, float mz){
        Vector3  targetLocation = mapController.player.transform.position + new Vector3(mx, 0f, mz);
        targetLocation.x = Mathf.Round(targetLocation.x* 2.5f) / 2.5f;
        targetLocation.z = Mathf.Round(targetLocation.z* 2.5f) / 2.5f;
        while(true){
            if (Vector3.Distance(mapController.player.transform.position, targetLocation) < 0.04f){
                mapController.player.transform.position = targetLocation;
                mapController.player.isExternalMoving = false;
                isSliding = false;
                break;
            }
            else if (Vector3.Distance(mapController.player.transform.position, targetLocation) > 0.7f){
                mapController.player.isExternalMoving = false;
                isSliding = false;
                break;
            }
            isSliding = true;
            mapController.player.isExternalMoving = true;
            mapController.player.transform.LookAt(targetLocation);
            mapController.player.transform.position += (targetLocation - mapController.player.transform.position).normalized * mapController.player.speed * Time.deltaTime * 1.5f;
            Debug.Log(mapController.player.transform.position);
            yield return null;
        }        
    }
}
}