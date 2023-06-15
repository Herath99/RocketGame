using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float thrustForce;  // The force applied to the rocket when thrusting
    public float rotateForce;  // The force applied to the rocket when rotating
    public float maxPower;
    public float powerConsumption;
    public float power;

    private Rigidbody rb;  // Reference to the rocket's Rigidbody component
    private bool isThrusting;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        power = maxPower;
    }

    void FixedUpdate()
    {
        isThrusting = false;

        if (Input.GetKey(KeyCode.W) && power > 0)
        {
            rb.AddRelativeForce(Vector3.up * thrustForce);
            isThrusting = true;
            power -= powerConsumption * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && power > 0)
        {
            rb.AddRelativeForce(Vector3.left * thrustForce);
        }
        else if (Input.GetKey(KeyCode.A) && power > 0)
        {
            rb.AddRelativeForce(Vector3.right * thrustForce);
        }

        if (!isThrusting)
        {
            rb.AddForce(Physics.gravity);
        }

        if (power <= 0)
        {
            // reset the game or call a function to handle the game over
        }
    }
}
