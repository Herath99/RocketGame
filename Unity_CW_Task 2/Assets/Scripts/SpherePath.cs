using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePath : MonoBehaviour
{

    public Transform[] waypoints; // an array of waypoints
    public float speed = 1.0f; // the speed of the path follower
    public float acceleration = 1.0f; // the acceleration of the path follower
    public float deceleration = 1.0f; // the deceleration of the path follower

    private int currentWaypoint; // the index of the current waypoint
    private Vector3 targetPosition; // the position of the current target
    private Vector3 velocity; // the current velocity of the path follower


    // Start is called before the first frame update
    void Start()
    {

        currentWaypoint = 0; // start from the first waypoint
        targetPosition = waypoints[currentWaypoint].position; // set the target position

    }

    // Update is called once per frame
    void Update()
    {

        // check if the target position has changed
        if (targetPosition != waypoints[currentWaypoint].position)
        {
            targetPosition = waypoints[currentWaypoint].position; // update the target position
        }

        // calculate the direction vector to the target position
        Vector3 direction = targetPosition - transform.position;
        float distance = direction.magnitude; // calculate the distance to the target

        // check if the path follower is close to the target position
        if (distance < 0.1f)
        {
            // update the current waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            targetPosition = waypoints[currentWaypoint].position; // set the new target position
        }

        // calculate the acceleration
        if (distance < acceleration * Time.deltaTime)
        {
            // ease in
            velocity += direction.normalized * (acceleration * Time.deltaTime - distance) / Time.deltaTime;
        }
        else if (distance > deceleration * Time.deltaTime)
        {
            // maintain the constant velocity
            velocity = direction.normalized * speed;
        }
        else
        {
            // ease out
            velocity -= direction.normalized * (distance - deceleration * Time.deltaTime) / Time.deltaTime;
        }

        // update the transform
        transform.position += velocity * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

}

