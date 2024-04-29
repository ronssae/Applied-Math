using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform enemyTF;
    [Range(0f, 5f)]
    public float radius;
    public float distance;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        bool isInside = false;

        Vector2 origin = transform.position;
        Vector2 enemy = enemyTF.position;

        Gizmos.DrawLine(origin, enemy);

        float pointA = enemy.x - origin.x;
        float pointB = enemy.y - origin.y;

        distance = Mathf.Sqrt(Mathf.Pow(pointA,2) + Mathf.Pow(pointB, 2));

        if(distance < radius)
        {
            isInside = true;
        }
        else
        {
            isInside = false;
        }
        Handles.color = isInside ? Color.red : Color.green;
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);
    }
#endif
}
