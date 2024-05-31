using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpingTest : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float duration; // Time in seconds to move from start to end

    private float elapsedTime;

    void Start()
    {
        startPoint.position = transform.position;
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        }
        else
        {
            transform.position = endPoint.position;
        }
    }
}
