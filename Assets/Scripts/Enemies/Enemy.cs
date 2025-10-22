using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class representing an enemy in the game
public abstract class Enemy : MonoBehaviour
{
    public string Type { get; protected set; }  // Type of enemy
    public Vector2 Position { get; protected set; }
    
    public abstract Vector2 Penalty(); // Abstract method that must be implemented by subclasses
}
