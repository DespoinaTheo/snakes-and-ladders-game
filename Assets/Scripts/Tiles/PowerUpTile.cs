using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subclass PowerUpTile inherits from Tile
public class PowerUpTile : Tile
{
    public GameObject powerUpInstance;  // Encapsulates PowerUp logic within this object
    private Vector2 NewPosition;

    // Calls base class Start method while adding specific behavior for PowerUpTile
    protected override void Start()
    {
        base.Start();  // Calls base class implementation
        Type = "PowerUp"; // Sets type for this specific tile

        // Assigns specific power-ups to the tile based on its position
        if (powerUpInstance.transform.position == new Vector3 (0.5f, -4.5f, 0f) || powerUpInstance.transform.position == new Vector3 (-4.5f, 2.5f, 0f))
        {
            powerUpInstance.AddComponent<FastForward>();  // Assigns a FastForward power-up
        }
        else if (powerUpInstance.transform.position == new Vector3 (0.5f, 4.5f, 0f) || powerUpInstance.transform.position == new Vector3 (0.5f, 0.5f, 0f))
        {
            powerUpInstance.AddComponent<ExtraRoll>();  // Assigns an ExtraRoll power-up
        }
        else if (powerUpInstance.transform.position == new Vector3 (-2.5f, -2.5f, 0f) || powerUpInstance.transform.position == new Vector3 (4.5f, 2.5f, 0f))
        {
            powerUpInstance.AddComponent<SkipSnake>();  // Assigns a SkipSnake power-up
        }
    }

    // Overrides OnLand to handle PowerUpTile-specific behavior
    public override Vector2 OnLand()
    {
        Debug.Log($"Player landed on a PowerUp tile at position {Position}. Gains a power-up!");

        // Checks and uses the correct power-up logic based on available components
        if (powerUpInstance != null)
        {
            FastForward fastForward = powerUpInstance.GetComponent<FastForward>();  // Checks for FastForward component
            if (fastForward != null)
            {
                NewPosition = fastForward.PowerUps();  // Uses FastForward power-up to determine new position
                return NewPosition;
            }

            ExtraRoll extraRoll = powerUpInstance.GetComponent<ExtraRoll>();  // Checks for ExtraRoll component
            if (extraRoll != null)
            {
                NewPosition = extraRoll.PowerUps();  // Uses ExtraRoll power-up to determine new position
                return NewPosition;
            }

            SkipSnake skipSnake = powerUpInstance.GetComponent<SkipSnake>();  // Checks for SkipSnake component
            if (skipSnake != null)
            {
                NewPosition = skipSnake.PowerUps();  // Uses SkipSnake power-up
                return Position;  // Player position doesn't change for SkipSnake, return original position
            }
        }

        return Position;  // Default return if no power-up is present
    }
}
