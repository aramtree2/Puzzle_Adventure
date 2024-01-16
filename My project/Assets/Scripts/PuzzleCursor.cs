using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class PuzzleCursor : MonoBehaviour
{
    [SerializeField]
    Material cursorMaterial;
    [SerializeField]
    Camera sceneCamera;
    [SerializeField]
    Player player;

    public Color blockColor;
    public Color objectColor;
    public Color ClickColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
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
                RoundedVec.y = Mathf.Round(targetVec.y * 2.5f) / 2.5f;
                RoundedVec.z = Mathf.Round(targetVec.z* 2.5f) / 2.5f;
                gameObject.transform.localScale = new Vector3(1,1,1);
                gameObject.transform.position = RoundedVec;
                cursorMaterial.SetColor("_EmissionColor",blockColor); 
            }
            else{
                BoxCollider boxCollider = clickObject.GetComponent<BoxCollider>();
                gameObject.transform.localScale = boxCollider.size * 1.25f;
                gameObject.transform.position = clickObject.transform.position;
                cursorMaterial.SetColor("_EmissionColor",objectColor);
            }
        }
        else{
            gameObject.transform.position = sceneCamera.transform.position + new Vector3(10f,10f,10f);
        }
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(ClickColorChange());
        }
    }

    IEnumerator ClickColorChange(){
        float time = 0f;
        while (time < 0.1f){
            time += Time.deltaTime;
            cursorMaterial.SetColor("_EmissionColor",ClickColor);  
            yield return null;
        }
    }
}
}