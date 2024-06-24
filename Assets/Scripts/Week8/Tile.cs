using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool currentTile;
    public bool targetTile;
    public bool Selectable;
    public bool Walkable;

    //Needed for BFS
    public bool Visited = false;
    public Tile Parent = null;
    public int Distance = 0;

    public List<Tile> AdjacencyList = new();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTile)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (targetTile)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Selectable)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }

    public void ResetValues()
    {
        AdjacencyList.Clear();
        currentTile = false;
        targetTile = false;
        Selectable = false;

        Visited = false;
        Parent = null;
        Distance = 0;
    }
    public void FindNeighbors(float jumpHeight)
    {
        ResetValues();
        CheckTiles(Vector3.forward, jumpHeight);
        CheckTiles(Vector3.back, jumpHeight);
        CheckTiles(Vector3.right, jumpHeight);
        CheckTiles(Vector3.left, jumpHeight);
    }
    public void CheckTiles(Vector3 Direction, float jumpHeight)
    {
        Vector3 HalfExtents = new(0.25f, (1 + jumpHeight), 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + Direction, HalfExtents);
        foreach (Collider item in colliders)
        {
            Tile tile = item.GetComponent<Tile>();
            if (tile != null && tile.Walkable)
            {
                RaycastHit hit;
                if (Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    AdjacencyList.Add(tile);
                }
            }
        }
    }
}
