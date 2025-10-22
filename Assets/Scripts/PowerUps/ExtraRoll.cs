using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass ExtraRoll inherits from PowerUp
public class ExtraRoll : PowerUp
{    
    void Start() // Initialize power-up properties
    {
        Type = "Extra Roll";
        Position = new Vector2(transform.position.x, transform.position.y);
    }
    // Overrides the abstract Penalty method from the Enemy class
    public override Vector2 PowerUps()
    {
        Game.Instance.ActivateExtraRoll(); // // Calls Game class to make player gain a turn
        return Position; // No movement effect
    }

}
