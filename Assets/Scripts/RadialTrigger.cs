using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
    public Transform enemyTF;
    [Range(0f, 5f)]
    public float radius;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        bool isInside = false; //Not Final pa, edit this part

        Vector2 origin = transform.position;
        Handles.color = isInside ? Color.red : Color.green;
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);
    }
#endif
}
