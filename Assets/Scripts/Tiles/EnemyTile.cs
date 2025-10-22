using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass EnemyTile inherits from Tile
public class EnemyTile : Tile
{
    private Vector2 NewPosition;
    public GameObject enemyInstance;  // Encapsulates logic for interacting with the enemy instance
    
    // Calls base class Start method while adding specific behavior for EnemyTile
    protected override void Start()
    {
        base.Start();  // Calls base class implementation
        Type = "Enemy";  // Sets the type for this tile

        // Assigns specific enemy behaviors based on tile position
        if (enemyInstance.transform.position == new Vector3 (4.5f, 4.5f, 0f) || enemyInstance.transform.position == new Vector3 (-3.5f, -2.5f, 0f) || enemyInstance.transform.position == new Vector3 (4.5f, -3.5f, 0f))
        {
            enemyInstance.AddComponent<StepBack>();  // Assigns a StepBack penalty behavior to the enemy instance
        }
        else if (enemyInstance.transform.position == new Vector3 (-0.5f, 3.5f, 0f) || enemyInstance.transform.position == new Vector3 (-1.5f, -0.5f, 0f) || enemyInstance.transform.position == new Vector3 (-1.5f, 1.5f, 0f))
        {
            enemyInstance.AddComponent<TurnLoss>();  // Assigns a TurnLoss penalty behavior to the enemy instance
        }
    }

    // Overrides OnLand to handle EnemyTile-specific behavior
    public override Vector2 OnLand()
    {
        Debug.Log($"Player landed on an Enemy tile at position {Position}. Prepare for battle!");

        // Checks and uses the appropriate penalty behavior based on available components in enemyInstance
        if (enemyInstance != null)
        {
            StepBack stepBack = enemyInstance.GetComponent<StepBack>();  // Checks for StepBack component
            if (stepBack != null)
            {
                NewPosition = stepBack.Penalty();  // Executes StepBack penalty and returns new position
                return NewPosition;
            }

            TurnLoss turnLoss = enemyInstance.GetComponent<TurnLoss>();  // Checks for TurnLoss component
            if (turnLoss != null)
            {
                NewPosition = turnLoss.Penalty();  // Executes TurnLoss penalty and returns new position
                return NewPosition;
            }
        }

        return Position;  // Default return if no penalty is applied
    }
}
