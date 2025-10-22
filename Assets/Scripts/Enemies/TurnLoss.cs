using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass TurnLoss inherits from Enemy
public class TurnLoss : Enemy
{
    void Start() // Initialize enemy properties
    {
        Type = "Turn Loss";
        Position = new Vector2(transform.position.x, transform.position.y);
    }
    // Overrides the abstract Penalty method from the Enemy class
    public override Vector2 Penalty()
    {
        Game.Instance.ActivateLoseTurn(); // Calls Game class to make player lose a turn 
        return Position; // No movement effect
    }
}
