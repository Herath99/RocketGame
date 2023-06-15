using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public Vector3 launchVelocity;
    public float coefficientOfRestitution = 0.75f; // the default value for e
    public float tolerance = 0.01f; // the default value for the tolerance

    private Vector3 velocity;
    private Vector3 acceleration;
    private Vector3 position;
    private float sphereRadius;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the variables
        velocity = launchVelocity;
        acceleration = new Vector3(0.0f, -9.81f, 0.0f);
        sphereRadius = 0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        // update the position using the Euler method
        position += velocity * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;

        // check if the sphere is colliding with the floor
        if (position.y - sphereRadius < 0 && velocity.y < 0)
        {
            // calculate the new velocity after the bounce
            Vector3 newVelocity = Vector3.Reflect(velocity, Vector3.up) * coefficientOfRestitution;

            // check if the bounce height is approaching zero
            if (Mathf.Abs(newVelocity.y / velocity.y) < tolerance)
            {
                velocity = Vector3.zero; // set velocity to zero
            }
            else
            {
                velocity = newVelocity; // update the velocity
            }
        }

 

        // update the transform
        transform.position = position;
    }
}
