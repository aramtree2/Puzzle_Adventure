using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class MapController : MonoBehaviour
    {
        public Player player;
        public void Click()
        {
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("PuzzleObject"))
                {
                    PuzzleObject puzzleObject = hitObject.GetComponent<PuzzleObject>();
                    Interact(puzzleObject);
                }

                else
                {
                    Vector3 clickedPosition = Input.mousePosition;
                    player.Travel(clickedPosition);
                }
            }
        }
        void Interact(PuzzleObject puzzleObject)
        {
            puzzleObject.Interact();
        }
    }
}