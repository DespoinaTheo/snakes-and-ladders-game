using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass StepBack inherits from Enemy
public class StepBack : Enemy
{
    private Vector2 NewPosition; // Position after applying the penalty

    // Dictionary mapping enemy start positions to end positions
    private Dictionary<Vector2, Vector2> SBPositions = new Dictionary<Vector2, Vector2>()
    {
        {new Vector2(4.5f, 4.5f), new Vector2(1.5f, 3.5f)},
        {new Vector2(-3.5f, -2.5f), new Vector2(-2.5f, -3.5f)},
        {new Vector2(4.5f, -3.5f), new Vector2(1.5f, -4.5f)}
    };
    
    void Start() // Initialize enemy properties
    {
        Type = "Step Back";
        Position = new Vector2(transform.position.x, transform.position.y);
    }

    // Overrides the abstract Penalty method from the Enemy class
    public override Vector2 Penalty()
    {
        NewPosition = SBPositions[Position]; // Moves player to a predefined position
        return NewPosition;
    }

}
