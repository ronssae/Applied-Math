using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int width, height;
    public GameObject TileFab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region GenerateGrid
    public void GenerateGrid()
    {
        if (TileFab == null)
        {
            Debug.LogError("Walang PreFab tanga");
            return;
        }
        //Loop through the grid positions

        //X - Axis
        for (int x = 0; x < width; x++)
        {
            //Y - Axis
            for(int y = 0; y < height; y++)
            {
                Vector3 Position = new Vector3(x, 0, y);
                //Instantiate the cube at the Calculated Position
                GameObject NewTile = Instantiate(TileFab, Position, Quaternion.identity);
                NewTile.transform.parent = transform;
                NewTile.tag = "Tile";
            }
        }
    }
    #endregion
    #region ClearGrid
    public void ClearGrid()
    {
        //Find all GameObjects tagged as "Tiles"
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            DestroyImmediate(tile);
        }
    }
    #endregion

    public void AssignMaterial()
    {
        //Find All GameObject with Tag as Tile
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        //Find All Material in Resources Folder with the name "Tile"
        Material mat = Resources.Load<Material>("Tile");
        foreach (GameObject t in tiles)
        {
            t.GetComponent<Renderer>().material = mat;
        }
    }
}
