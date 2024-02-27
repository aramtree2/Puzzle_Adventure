using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle{
public class ToggleBox : PuzzleObject
{
    [SerializeField] MapController mapController;
    [SerializeField] GameObject toggleBox;

    Renderer toggleRenderer;
    public bool isActivated;
    [SerializeField] int toggleBoxNumber;

    // disables toggle when stage is cleared
    public bool toggleAbility;

    // blue
    Color activatedColor = new Color(0, 0.416f, 0.655f, 1.0f);
    // yellow
    Color deactivatedColor = new Color(0.996f, 0.8f, 0.008f, 1.0f);

    private void Start()
    {
        toggleRenderer = toggleBox.GetComponentInChildren<Renderer>();
        toggleAbility = true;
    }

    private void Update()
    {
        if(isActivated)
            toggleRenderer.material.SetColor("_Color", activatedColor);
        else
            toggleRenderer.material.SetColor("_Color", deactivatedColor);
    }

    public override void interact()
    {
        if(Vector3.Distance(mapController.player.transform.position, transform.position) < 0.8f)
            mapController.GetComponent<Puzzle2_3>().ToggleNearby(toggleBoxNumber);
    }


    public void ToggleActivate()
    {
        if (toggleAbility)
        {
            if(isActivated)
                isActivated = false;
            else
                isActivated = true;
        }
    }
}
}