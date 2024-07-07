using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAI : MonoBehaviour
{
    List<Tile> SelectableTiles = new ();
    GameObject[] Tiles;

    Stack<Tile> Path = new();
    Tile CurrentTile;

    public int Move = 5;
    public float JumpHeight = 2;
    public float MoveSpeed;

    Vector3 Velocity = new();
    Vector3 Heading = new();

    float HalfHeight = 0;

    protected void Init()
    {
        Tiles = GameObject.FindGameObjectsWithTag("Tile");

        HalfHeight = GetComponent<Collider>().bounds.extents.y;
    }

    public void GetCurrentTile()
    {
        CurrentTile = GetTargetTile(gameObject);
        CurrentTile.currentTile = true;
    }
    public Tile GetTargetTile(GameObject Target)
    {
        RaycastHit hit;
        Tile tile = null;
        if (Physics.Raycast(Target.transform.position, Vector3.down, out hit, 1))
        {
            tile = hit.collider.GetComponent<Tile>();
        }
        return tile;
    }

    public void ComputeAdjacencyList()
    {
        foreach(GameObject tile in Tiles) 
        {
            Tile t = tile.GetComponent<Tile>();
            t.FindNeighbors(JumpHeight);
        }
    }

    public void FindSelectableTiles()
    {
        ComputeAdjacencyList();
        GetCurrentTile();

        Queue<Tile> process = new Queue<Tile>();
        process.Enqueue(CurrentTile);
        CurrentTile.Visited = true;
        while(process.Count > 0)
        {
            Tile t = process.Dequeue();

            SelectableTiles.Add(t);
            t.Selectable = true;
            if (t.Distance < Move)
            {
                foreach (Tile tile in t.AdjacencyList)
                {
                    if (!tile.Visited)
                    {
                        tile.Parent = t;
                        tile.Visited = true;
                        tile.Distance = 1 + t.Distance;
                        process.Enqueue(tile);
                    }
                }
            }
        }
    }
}
