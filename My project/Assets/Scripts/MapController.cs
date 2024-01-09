using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace puzzle{
public class MapController : MonoBehaviour
{
    public Player player;

    [SerializeField]
    private Camera sceneCamera;

    private IEnumerator travelCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Click();
        }
    }

    void Click(){
        if(travelCoroutine != null) StopCoroutine(travelCoroutine);

        Vector3 ClickPos = Input.mousePosition;
        Ray ray = sceneCamera.ScreenPointToRay(ClickPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)){
            GameObject clickObject = hit.transform.gameObject;
            PuzzleObject puzzleObject = clickObject.GetComponent<PuzzleObject>();
            if(puzzleObject == null){
                Vector3 targetVec = hit.point;
                Vector3 RoundedVec;
                RoundedVec.x = Mathf.Round(targetVec.x * 2.5f) / 2.5f;
                RoundedVec.y = Mathf.Round(targetVec.y * 2.5f) / 2.5f;;
                RoundedVec.z = Mathf.Round(targetVec.z* 2.5f) / 2.5f;
                travelCoroutine = player.Travel(RoundedVec);
                StartCoroutine(travelCoroutine);
            }
            else{
                puzzleObject.interact();
            }
        }
        else{
            return;
        }
    }
}
}

