using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass SnakeTile inherits from Tile 
public class SnakeTile : Tile
{
    private Vector2 NewPosition;

    // Dictionary mapping snake start positions to end positions
    private Dictionary<Vector2, Vector2> snakePositions = new Dictionary<Vector2, Vector2>()
    {
        {new Vector2(1.5f, -2.5f), new Vector2(-0.5f, -4.5f)},
        {new Vector2(-4.5f, -1.5f), new Vector2(-2.5f, -4.5f)}, 
        {new Vector2(-2.5f, -0.5f), new Vector2(-2.5f, -3.5f)},
        {new Vector2(1.5f, 0.5f), new Vector2(3.5f, -1.5f)},
        {new Vector2(0.5f, 1.5f), new Vector2(-0.5f, -0.5f)},
        {new Vector2(-0.5f, 2.5f), new Vector2(-2.5f, 0.5f)},
        {new Vector2(3.5f, 3.5f), new Vector2(2.5f, 0.5f)},
        {new Vector2(-3.5f, 4.5f), new Vector2(-4.5f, -0.5f)}
    };
    
    // Overrides the base class's Start method
    protected override void Start()
    {
        base.Start(); // Calls the base Tile class's Start method
        Type = "Snake"; // Sets the specific type for this tile
    }

    // Overrides the OnLand method to provide a unique behavior for Snake tiles
    public override Vector2 OnLand()
    {
        Debug.Log($"Player landed on a Snake tile at position {Position}. New position: {NewPosition}!");
        NewPosition = snakePositions[Position]; // Moves player to the assigned new position
        return NewPosition;
    }
}
