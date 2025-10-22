using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass FastForward inherits from PowerUp
public class FastForward: PowerUp
{
    private Vector2 NewPosition; // Position after applying the power-up

    // Dictionary mapping enemy start positions to end positions
    private Dictionary<Vector2, Vector2> FFPositions = new Dictionary<Vector2, Vector2>()
    {
        {new Vector2(0.5f, -4.5f), new Vector2(4.5f, -4.5f)},
        {new Vector2(-4.5f, 2.5f), new Vector2(-1.5f, 3.5f)}
    };
    
    void Start() // Initialize power-up properties
    {
        Type = "Fast Forward";
        Position = new Vector2(transform.position.x, transform.position.y);
    }
    // Overrides the abstract PowerUps method from the PowerUp class
    public override Vector2 PowerUps()
    {
        NewPosition = FFPositions[Position]; // Moves player to a predefined position
        return NewPosition;
    }
}