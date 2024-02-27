using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace puzzle
{
    public class LinkBox : PuzzleObject
    {
        [SerializeField] MapController mapController;

        [SerializeField] GameObject linkBox;
        // starting or ending point
        public bool linkPoint;
        // link color reference
        public int linkColor;

        // default, dark grey
        Color linkColor0 = new Color(0.1f, 0.1f, 0.1f, 1.0f);
        // white
        Color linkColor1 = new Color(1, 1, 1, 1.0f);
        // red
        Color linkColor2 = new Color(0.73f, 0.05f, 0.18f, 1.0f);
        // yellow
        Color linkColor3 = new Color(1.0f, 0.8f, 0.01f, 1.0f);
        // blue
        Color linkColor4 = new Color(0, 0.42f, 0.66f, 1.0f);

        Renderer linkRenderer;

        private void Start()
        {
            linkRenderer = linkBox.GetComponentInChildren<Renderer>();

            switch (linkColor)
            {
                case 0 :
                    linkRenderer.material.SetColor("_Color", linkColor0);
                    break;

                case 1 :
                    linkRenderer.material.SetColor("_Color", linkColor1);
                    break;

                case 2 :
                    linkRenderer.material.SetColor("_Color", linkColor2);
                   break;

                case 3 :
                    linkRenderer.material.SetColor("_Color", linkColor3);
                    break;

                case 4 :
                    linkRenderer.material.SetColor("_Color", linkColor4);
                    break;
            }
        }

        public override void interact()
        {
            Ray ray = mapController.sceneCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit, 100))
            {
                mapController.GetComponent<Puzzle2_4>().linkMode = Mathf.Abs(Vector3.Distance(hit.point, transform.position)) < 0.5f
                                                                && Input.GetMouseButtonDown(0) 
                                                                && Mathf.Abs(Vector3.Distance(hit.point, mapController.player.transform.position)) < 0.5f;
                
                if (linkPoint)
                {
                    switch (mapController.GetComponent<Puzzle2_4>().linkModeColor)
                    {
                        case 0 :
                            mapController.GetComponent<Puzzle2_4>().linkMode = true;
                            mapController.GetComponent<Puzzle2_4>().linkModeColor = linkColor;
                            break;

                        case 1 :
                            if (linkColor == 1)
                            {
                                mapController.GetComponent<Puzzle2_4>().linkModeColor = 0;
                                mapController.GetComponent<Puzzle2_4>().linkMode = false;
                            }
                            break;

                        case 2 :
                            if (linkColor == 2)
                            {
                                mapController.GetComponent<Puzzle2_4>().linkModeColor = 0;
                                mapController.GetComponent<Puzzle2_4>().linkMode = false;
                            }
                            break;

                        case 3 :
                            if (linkColor == 3)
                            {
                                mapController.GetComponent<Puzzle2_4>().linkModeColor = 0;
                                mapController.GetComponent<Puzzle2_4>().linkMode = false;
                            }
                            break;

                        case 4 :
                            if (linkColor == 4)
                            {
                                mapController.GetComponent<Puzzle2_4>().linkModeColor = 0;
                                mapController.GetComponent<Puzzle2_4>().linkMode = false;
                            }
                            break;
                    }
                }
                else
                {
                    if (mapController.GetComponent<Puzzle2_4>().linkMode)
                        SwitchColor();
                }
            }
        }

        public void SwitchColor()
        {
            if (mapController.GetComponent<Puzzle2_4>().linkMode)
            {
                switch (mapController.GetComponent<Puzzle2_4>().linkModeColor)
                {
                    case 1 :
                        linkRenderer.material.SetColor("_Color", linkColor1);
                        break;

                    case 2 :
                        linkRenderer.material.SetColor("_Color", linkColor2);
                        break;

                    case 3 :
                        linkRenderer.material.SetColor("_Color", linkColor3);
                        break;

                    case 4 :
                        linkRenderer.material.SetColor("_Color", linkColor4);
                        break;
                }
            }
        }
    }
}