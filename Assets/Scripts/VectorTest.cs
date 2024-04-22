using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour
{
    public Transform aTransform;
    public Transform bTransform;
    public float distance;

    private void OnDrawGizmos()
    {
        Vector2 a = aTransform.position;
        Vector2 b = bTransform.position;

        //Vector2 pt = transform.position;
        //Vector2 dirToPt = pt.normalized;
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(Vector3.zero, dirToPt);

        Gizmos.DrawLine(a, b);

        float pointA = b.x - a.x;
        float pointB = b.y - a.y;

        distance = Mathf.Sqrt(pointA * pointA + pointB * pointB);
        Debug.Log(distance);
    }
}
