using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace puzzle{
public class PuzzleObject : MonoBehaviour
{
    public virtual void interact(){}
    public bool CheckCanPass(Vector3 location){
        int passLayerMask = 1 << LayerMask.NameToLayer("Solid") | 1 << LayerMask.NameToLayer("Obstacle");
        Collider[] colls = Physics.OverlapSphere(transform.position + new Vector3(0f, 0.2f, 0f) + location, 0.1f, passLayerMask);
        return !colls.Any();
    }
    public bool CheckCanStep(Vector3 location){
        RaycastHit hit;
        int stepLayerMask = 1 << LayerMask.NameToLayer("Solid");
        return Physics.Raycast(transform.position + new Vector3(0f, 0.2f, 0f) + location, new Vector3(0f, -1f, 0f), out hit, 0.4f, stepLayerMask);
    }
}
}