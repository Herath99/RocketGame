using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour
{
    public GameObject boulder;  // Reference to the boulder GameObject
    public GameObject rocket;  // Reference to the rocket GameObject
    public float distance;  // The distance at which the tether will attach to the boulder

    private HingeJoint hingeJoint;  // Reference to the hinge joint component

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, boulder.transform.position) <= distance)
        {
            hingeJoint.connectedBody = boulder.GetComponent<Rigidbody>();
            hingeJoint.enableCollision = false;
        }
    }
}
