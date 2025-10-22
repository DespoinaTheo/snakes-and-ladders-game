using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass LadderTile inherits from Tile 
public class LadderTile : Tile
{
    private Vector2 NewPosition;

    // Dictionary mapping ladder start positions to end positions
    private Dictionary<Vector2, Vector2> ladderPositions = new Dictionary<Vector2, Vector2>()
    {
        {new Vector2(-1.5f, -4.5f), new Vector2(-0.5f, -2.5f)},
        {new Vector2(2.5f, -3.5f), new Vector2(0.5f, -0.5f)}, 
        {new Vector2(2.5f, -1.5f), new Vector2(3.5f, -0.5f)},
        {new Vector2(4.5f, -0.5f), new Vector2(3.5f, 1.5f)},
        {new Vector2(-3.5f, -0.5f), new Vector2(-2.5f, 1.5f)},
        {new Vector2(-3.5f, 1.5f), new Vector2(-4.5f, 3.5f)},
        {new Vector2(1.5f, 2.5f), new Vector2(3.5f, 4.5f)},
        {new Vector2(-2.5f, 3.5f), new Vector2(-0.5f, 4.5f)}
    };

    // Overrides the base class's Start method
    protected override void Start()
    {
        base.Start(); // Calls the base class Start method
        Type = "Ladder"; // Sets the specific type of this tile
    }

    // Overrides OnLand() to implement unique behavior for Ladder tiles
    public override Vector2 OnLand()
    {
        NewPosition = ladderPositions[Position]; // Moves player to the new position
        Debug.Log($"Player landed on a Ladder tile at position {Position}. New position: {NewPosition}!");
        return NewPosition;
    }
}
