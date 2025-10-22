using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 position = new Vector2(-5.5f, -4.5f); // Position variable
    public GameObject Dice; // Dice reference
    public int skip = 0; // Skip counter for SkipSnake tile effect

    // AUdio
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip1;
    [SerializeField] private AudioClip clip2;


    // Player movement based on dice roll
    public void Movement()
    {
        // Accessing the Dice component
        Dice diceScript = Dice.GetComponent<Dice>();
        int diceNumber = diceScript.number;

        if (position.y == -4.5f || position.y == -2.5f || position.y == -0.5f || position.y == 1.5f || position.y == 3.5f)
        {
            // Moves right if within the row's limit, otherwise moves up and wraps around
            if (diceNumber <= Math.Abs(4.5f - position.x))
            {
                position.x += diceNumber;
            }
            else
            {
                position.y += 1;
                position.x = 4.5f - (diceNumber - Math.Abs(4.5f - position.x) - 1);
            }
        }
        else if (position.y == -3.5f || position.y == -1.5f || position.y == 0.5f || position.y == 2.5f)
        {
            // Moves left if within the row's limit, otherwise moves up and wraps around
            if (diceNumber <= Math.Abs(-4.5f - position.x))
            {
                position.x -= diceNumber;
            }
            else
            {
                position.y += 1;
                position.x = -4.5f + (diceNumber - Math.Abs(-4.5f - position.x) - 1);
            }
        }
        // Handles movement when reaching the last row
        else if (position.y == 4.5f)
            {
                if(diceNumber == Math.Abs(-4.5f - position.x))
                {
                    position.x = -4.5f;
                }
                else if (diceNumber < Math.Abs(-4.5f - position.x)) 
                {
                    position.x = position.x -= diceNumber;
                }
            }   

        MoveToTarget();
    }

    // Updates the player's position
    public void MoveToTarget()
    {
        transform.position = new Vector2(position.x, position.y);
    }

    // Handles player's collisions with the board tiles
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        // All tile types inherit from Tile but have different behaviors (polymorphism)
        Tile tile = collisionInfo.gameObject.GetComponent<Tile>();
        if (tile != null)
        {
            if (tile is SnakeTile)
            {
                if (skip == 0) // Checks if the player can skip the snake
                {
                    source.PlayOneShot(clip1, 1f);
                    position = tile.OnLand();  // Calls overridden method for SnakeTile
                    Invoke("MoveToTarget", 0.3f);
                }
                else
                {
                    skip -=1;
                }
            }
            else if (tile is LadderTile)
            {
                source.PlayOneShot(clip2, 1f);
                position = tile.OnLand(); // Calls overridden method for LadderTile
                Invoke("MoveToTarget", 0.3f);
            }
            else if (tile is PowerUpTile)
            {
                source.PlayOneShot(clip2, 1f);
                position = tile.OnLand(); // Calls overridden method for PowerUpTile
                Invoke("MoveToTarget", 0.3f);
            }
            else if (tile is EnemyTile)
            {
                source.PlayOneShot(clip1, 1f);
                position = tile.OnLand(); // Calls overridden method for EnemyTile
                Invoke("MoveToTarget", 0.3f);
            }
            else
            {
                tile.OnLand(); // Default tile behavior
            }
        
        }
       
    }
}