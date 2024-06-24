using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GridGenerator gridGenerator = (GridGenerator)target;
        if (GUILayout.Button("Generate Grid"))
        {
            gridGenerator.GenerateGrid();
        }
        if (GUILayout.Button("Clear Grid"))
        {
            gridGenerator.ClearGrid();
        }
        if (GUILayout.Button("Assign Material"))
        {
            gridGenerator.AssignMaterial(); 
        }
        if (GUILayout.Button("Assign Tile Script"))
        {
            gridGenerator.AssignTileScript();
        }
    }

    [MenuItem("Tools/Generate Grid")]

    public static void GenerateGridMenu()
    {
        GridGenerator gridGen = FindAnyObjectByType<GridGenerator>();
        if (gridGen != null)
        {
            gridGen.GenerateGrid();
        }
        else
        {
            Debug.LogError("Wala daw Grid Generator sa Scene Bobo");
        }
    }
}
