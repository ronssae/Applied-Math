using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSelector : MonoBehaviour, ISelector
{
    [SerializeField] string SelectableTag = "Selectable";
    public List<SelectableText> selectables; 
    public float Threshold;
    private Transform _selection;

    public void Check(Ray ray)
    {
        _selection = null;
        var closest = 0f;
        for (int i = 0; i < selectables.Count; i++)
        {
            Vector3 vector1 = ray.direction;
            Vector3 vector2 = selectables[i].transform.position - ray.origin;

            float LookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            selectables[i].LookPercent = LookPercentage;
            if (LookPercentage > Threshold && LookPercentage > closest) 
            {
                closest = LookPercentage;
                _selection = selectables[i].transform;
            }
        }
    }
    public Transform GetSelection() { return _selection; }
}
