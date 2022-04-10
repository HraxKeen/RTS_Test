using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    NavMeshAgent agent;

    public float rotatespeedMovement = 0.1f;
    float rotateVelocity;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Pressing left mouse button
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Chech if raycast hit something tat uses navmesh
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //MOVEMENT
                //Have the player move to the raycast/hit point
                agent.SetDestination(hit.point);

                //ROTATION
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotatespeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0,rotationY,0);
            }
        }
    }
}
