using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // target position (mouse rightclick)
    private Vector3 targetVec;

    // vector used in function Travel
    private Vector3 moveVec;
    private Vector3 originVec;

    // mouse position
    private Vector3 mousePos;

    Animator anim;

    [SerializeField]
    private Camera sceneCamera;

    [SerializeField]
    private LayerMask placementLayerMask;

    private bool isMoving;
    private bool isTravel;

    // number of x,z tiles left until target position
    private float xAxis;
    private float zAxis;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Locate();
        Travel();
    }

    // teleports player to target position
    public void Locate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveVec = GetWorldPosition();
            transform.position = moveVec;
        }
    }

    // moves player by one block (0.4 on coordinates)
    public void Move(int direction)
    {
        switch (direction)
        {
            case 7:
                if (!isMoving)
                {
                    // target position
                    moveVec = transform.position + new Vector3(-0.4f, 0, 0.4f);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        xAxis++;
                        zAxis--;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }                
                break;

            case 8:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(0, 0, 0.4f);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        zAxis--;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;

            case 9:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(0.4f, 0, 0.4f);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        xAxis--;
                        zAxis--;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;

            case 6:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(0.4f, 0, 0);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        xAxis--;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;

            case 3:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(0.4f, 0, -0.4f);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        xAxis--;
                        zAxis++;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;

            case 2:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(0, 0, -0.4f);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        zAxis++;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;

            case 1:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(-0.4f, 0, -0.4f);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        xAxis++;
                        zAxis++;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;

            case 4:
                if (!isMoving)
                {
                    moveVec = transform.position + new Vector3(-0.4f, 0, 0);
                    isMoving = true;
                }
                else
                {
                    if (Vector3.Distance(transform.position, moveVec) < 0.02f)
                    {
                        xAxis++;
                        isMoving = false;
                        break;
                    }

                    transform.position += (moveVec - transform.position).normalized * speed * Time.deltaTime;
                }
                break;
        }

        anim.SetBool("isMoving", isMoving);
        transform.LookAt(moveVec);
    }

    // scans nearby gameobjects
    public GameObject[] Near()
    {
        // index 0 and 5 are not used
        GameObject[] near = new GameObject[10];

        RaycastHit hit;

        // keypad reference, player is at 5

        if (Physics.Raycast(transform.position, new Vector3(-0.4f, 0.2f, 0.4f), out hit, 1f))
            near[7] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(0, 0.2f, 0.4f), out hit, 1f))
            near[8] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(0.4f, 0.2f, 0.4f), out hit, 1f))
            near[9] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(0.4f, 0.2f, 0), out hit, 1f))
            near[6] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(0.4f, 0.2f, -0.4f), out hit, 1f))
            near[3] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(0, 0.2f, -0.4f), out hit, 1f))
            near[2] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(-0.4f, 0.2f, -0.4f), out hit, 1f))
            near[1] = hit.collider.gameObject;

        if (Physics.Raycast(transform.position, new Vector3(-0.4f, 0.2f, 0), out hit, 1f))
            near[4] = hit.collider.gameObject;

        // debug : hit == red, null = green

        Debug.Log("----------------------------");

        Debug.Log("7" + near[7]);
        if (near[7])
        {
            Debug.DrawRay(transform.position, new Vector3(-0.4f, 0.2f, 0.4f), Color.red, 10f);
            Debug.Log(near[7].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(-0.4f, 0.2f, 0.4f), Color.green, 10f);

        Debug.Log("8" + near[8]);
        if (near[8])
        {
            Debug.DrawRay(transform.position, new Vector3(0, 0.2f, 0.4f), Color.red, 10f);
            Debug.Log(near[8].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(0, 0.2f, 0.4f), Color.green, 10f);

        Debug.Log("9" + near[9]);
        if (near[9])
        {
            Debug.DrawRay(transform.position, new Vector3(0.4f, 0.2f, 0.4f), Color.red, 10f);
            Debug.Log(near[9].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(0.4f, 0.2f, 0.4f), Color.green, 10f);

        Debug.Log("6" + near[6]);
        if (near[6])
        {
            Debug.DrawRay(transform.position, new Vector3(0.4f, 0.2f, 0), Color.red, 10f);
            Debug.Log(near[6].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(0.4f, 0.2f, 0), Color.green, 10f);

        Debug.Log("3" + near[3]);
        if (near[3])
        {
            Debug.DrawRay(transform.position, new Vector3(0.4f, 0.2f, -0.4f), Color.red, 10f);
            Debug.Log(near[3].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(0.4f, 0.2f, -0.4f), Color.green, 10f);
            
        Debug.Log("2" + near[2]);
        if (near[2])
        {
            Debug.DrawRay(transform.position, new Vector3(0, 0.2f, -0.4f), Color.red, 10f);
            Debug.Log(near[2].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(0, 0.2f, -0.4f), Color.green, 10f);

        Debug.Log("1" + near[1]);
        if (near[1])
        {
            Debug.DrawRay(transform.position, new Vector3(-0.4f, 0.2f, -0.4f), Color.red, 10f);
            Debug.Log(near[1].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(-0.4f, 0.2f, -0.4f), Color.green, 10f);

        Debug.Log("4" + near[4]);
        if (near[4])
        {
            Debug.DrawRay(transform.position, new Vector3(-0.4f, 0.2f, 0), Color.red, 10f);
            Debug.Log(near[4].name);
        }
        else
            Debug.DrawRay(transform.position, new Vector3(-0.4f, 0.2f, 0), Color.green, 10f);


        return near;
    }

    // moves player to target location using Near and Move function
    public void Travel()
    {
        GameObject[] near = new GameObject[10];

        if (Input.GetMouseButtonDown(1))
        {
            // save target position

            targetVec = GetWorldPosition();
            isTravel = true;

            xAxis = (targetVec.x - transform.position.x) / 0.4f;
            xAxis = Mathf.Round(xAxis);
            zAxis = (targetVec.z - transform.position.z) / 0.4f;
            zAxis = Mathf.Round(zAxis);
        }
        
        if (isTravel)
        {
            if (!isMoving)
            {
                // reset gameobject array
                for (int index = 0; index < 10; index++)
                    near[index] = null;

                near = Near();
            }

            if (xAxis > 0)
            {
                if (zAxis > 0)
                {
                    if (!near[8] && !near[6] && !near[9])
                        Move(9);
                    else if ((near[6] || near[9]) && !near[8])
                        Move(8);
                    else if (near[8] && !near[6])
                        Move(6);
                    else if (near[8] && near[9] && near[6])
                        return;
                }
                else if (zAxis < 0)
                {
                    if (!near[6] && !near[2] && !near[3])
                        Move(3);
                    else if ((near[3] || near[6]) && near[2])
                        Move(2);
                    else if (near[2] && !near[6])
                        Move(6);
                    else if (near[6] && near[2] && near[3])
                        return;
                }   
                else if (zAxis == 0)
                {
                    if (!near[6])
                        Move(6);
                    else if (near[6])
                        return;
                }    
            }
            else if (xAxis < 0)
            {
                if (zAxis > 0)
                {
                    if (!near[8] && !near[4] && !near[7])
                        Move(7);
                    else if ((near[4] || near[7]) && !near[8])
                        Move(8);
                    else if (near[8] && !near[4])
                        Move(4);
                    else if (near[8] && near[7] && near[4])
                        return;
                }
                else if (zAxis < 0)
                {
                    if (!near[4] && !near[2] && !near[1])
                        Move(1);
                    else if ((near[1] || near[4]) && !near[2])
                        Move(2);
                    else if (near[2] && !near[4])
                        Move(4);
                    else if (near[4] && near[2] && near[1])
                        return;
                }
                else if (zAxis == 0)
                {
                    if (!near[4])
                        Move(4);
                    else if (near[4])
                        Move(4);
                }
            }
            else if (xAxis == 0)
            {
                if (zAxis > 0)
                {
                    if (!near[8])
                        Move(8);
                    else if (near[8])
                        return;
                }
                else if (zAxis < 0)
                {
                    if (!near[2])
                        Move(2);
                    else if (near[2])
                        return;
                }
                else if (zAxis == 0)
                {
                    return;
                }
            }

            if ((xAxis == 0) && (zAxis == 0))
                isTravel = false;
        }
    }

    public Vector3 GetWorldPosition()
    {
        mousePos = Input.mousePosition;

        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
            targetVec = hit.point;

        Vector3 moveVec;
        moveVec.x = Mathf.Round(targetVec.x);
        moveVec.y = transform.position.y;
        moveVec.z = Mathf.Round(targetVec.z);

        return moveVec;
    }
}