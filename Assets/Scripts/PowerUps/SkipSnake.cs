using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass SkipSnake inherits from PowerUp
public class SkipSnake : PowerUp
{
    public void Start() // Initialize power-up properties
    {
        Type = "Skip Snake";
        Position = new Vector2(transform.position.x, transform.position.y);
    }
    // Overrides the abstract PowerUps method from the PowerUp class
    public override Vector2 PowerUps()
    {
        // Checks if the current game round is odd or even to determine which player receives the power-up
        if (Game.round %2 != 0) // if round is odd
        {
            // Detects Player1 on scene and increases its skip 
            Player player = GameObject.Find("Player1").GetComponent<Player>();
            player.skip +=1;
        }
        else // if round is even
        {
            // Detects Player2 on scene and increases its skip 
            Player player = GameObject.Find("Player2").GetComponent<Player>();
            player.skip +=1;
        }
        return Position; // No movement effect
    }
}
