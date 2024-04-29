using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlerpTest : MonoBehaviour
{
    public Transform StartPoint, EndPoint, Center;
    public int Count;
    public float Radius;

    private void OnDrawGizmos()
    {
        foreach(var point in EvaluateSlerpPoints(StartPoint.position, EndPoint.position, Center.position, Count))
        {
            Gizmos.DrawSphere(point, Radius);
        }
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(Center.position, Radius * 2);
    }
    IEnumerable<Vector3> EvaluateSlerpPoints(Vector3 start, Vector3 end, Vector3 center, int count)
    {
        var StartRelativeCenter = start - center;
        var EndRelativeCenter = end - center;

        var f = 1f / count;
        for (float i = 0; i < 1+f; i+=f)
        {
            yield return Vector3.Slerp(StartRelativeCenter, EndRelativeCenter, i) + center;
        }
    }
}
