using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public float rotateSpeed;  // The speed at which the obstacle rotates
    public float oscillationSpeed;  // The speed at which the obstacle oscillates
    public float oscillationDistance;  // The distance of the obstacle's oscillation

    private Vector3 startPosition;  // The starting position of the obstacle

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        transform.position = startPosition + (Vector3.up * Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance);
    }
}
