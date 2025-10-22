using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class representing a power-up in the game
public abstract class PowerUp : MonoBehaviour
{
    public string Type { get; protected set; } // Type of power-up
    public Vector2 Position { get; protected set; }
    
    public abstract Vector2 PowerUps(); // Abstract method that must be implemented by subclasses

}
