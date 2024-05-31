using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTowardsTest : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2.0f; // Units per second

    void Start()
    {
        transform.position = startPoint.position;
    }

    void Update()
    {
        if (transform.position != endPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }
}
