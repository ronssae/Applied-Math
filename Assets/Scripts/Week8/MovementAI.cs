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
        Tile tile = null;
        return tile;
    }
}
