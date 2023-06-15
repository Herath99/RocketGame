using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder3 : MonoBehaviour
{
    public float mass;  // The mass of the boulder
    public float powerConsumption;  // The amount of power consumed per second of thrust

    private Rigidbody rb; // Reference to the boulder's Rigidbody component

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    public void ApplyForce(Vector3 force)
    {
        rb.AddForce(force * powerConsumption * Time.deltaTime);
    }
}
