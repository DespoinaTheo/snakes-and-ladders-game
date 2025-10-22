using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class representing a generic tile on the board
public class Tile : MonoBehaviour
{
    // Properties with protected setters allow derived classes to modify them but prevent external modification
    public string Type { get; protected set; }
    public Vector2 Position { get; protected set; }

    // Initializes the tile's position based on its scene placement
    protected virtual void Start()
    {
        Position = new Vector2(transform.position.x, transform.position.y); // Retrieves position from the scene object
    }

    // This method can be overridden by derived tile classes to implement custom behavior
    public virtual Vector2 OnLand()
    {
        Debug.Log($"Player landed on a Normal tile at position {Position}.");
        return Position; // Returns the tile's position (default behavior)
    }
}
