using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board: MonoBehaviour
{
    // Board size and starting points
    private float start_x = -4.5f;
    private float start_y = -4.5f;
    private int rows = 10;
    private int cols = 10;
    
    private List<Vector2> positions = new List<Vector2>(); // List with all tile positions on board

    // Prefabs for different tile types
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject snakeTilePrefab;
    [SerializeField] private GameObject ladderTilePrefab;
    [SerializeField] private GameObject enemyTilePrefab;
    [SerializeField] private GameObject powerUpTilePrefab;

    // List for specific tile-type positions
    private List<Vector2> powerUpPositions = new List<Vector2>()
    {
        new Vector2(0.5f, -4.5f),
        new Vector2(-2.5f, -2.5f),
        new Vector2(0.5f, 0.5f),
        new Vector2(-4.5f, 2.5f),
        new Vector2(4.5f, 2.5f),
        new Vector2(0.5f, 4.5f)
    };

    private List<Vector2> enemyPositions = new List<Vector2>()
    {
        new Vector2(4.5f, -3.5f),
        new Vector2(-3.5f, -2.5f),
        new Vector2(-1.5f, -0.5f),
        new Vector2(-1.5f, 1.5f),
        new Vector2(-0.5f, 3.5f),
        new Vector2(4.5f, 4.5f)
    };
    private List <Vector2> snakePositions = new List<Vector2>()
    {
        new Vector2(1.5f, -2.5f),
        new Vector2(-4.5f, -1.5f),
        new Vector2(-2.5f, -0.5f), 
        new Vector2(1.5f, 0.5f), 
        new Vector2(0.5f, 1.5f),
        new Vector2(-0.5f, 2.5f), 
        new Vector2(3.5f, 3.5f),
        new Vector2(-3.5f, 4.5f)
    };

    private List<Vector2> ladderPositions = new List<Vector2>()
    {
        new Vector2(-1.5f, -4.5f), 
        new Vector2(2.5f, -3.5f),
        new Vector2(2.5f, -1.5f), 
        new Vector2(4.5f, -0.5f), 
        new Vector2(-3.5f, -0.5f),
        new Vector2(-3.5f, 1.5f),
        new Vector2(1.5f, 2.5f), 
        new Vector2(-2.5f, 3.5f)
    };
    void Start()
    {
        // Generates the positions for the board
        positionGenerate();
    }

     public void positionGenerate() // Generates all board positions automatically
    {
        for (int i = 0; i < rows; i++) 
        {
            for (int j = 0; j < cols; j++)
            { 
                float x = start_x + i;
                float y = start_y + j;
                positions.Add(new Vector2(x, y));
            }
        }
    }
    public void BoardBuild() // Board built by instantiating the correct type of tile at each position.
    {
        foreach (var position in positions)
        {
            GameObject tile; // Different tile types share a common parent class (polymorphism)

            if (powerUpPositions.Contains(position))
            {
                tile = Instantiate(powerUpTilePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                PowerUpTile powerUpTile = tile.GetComponent<PowerUpTile>();
                tile.name = "PowerUp Tile (" + position.x + ", " + position.y + ")";
            }
            else if (enemyPositions.Contains(position))
            {
                tile = Instantiate(enemyTilePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                EnemyTile enemyTile = tile.GetComponent<EnemyTile>();
                tile.name = "Enemy Tile (" + position.x + ", " + position.y + ")";
            }
            else if (snakePositions.Contains(position))
            {
                tile = Instantiate(snakeTilePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                SnakeTile snakeTile = tile.GetComponent<SnakeTile>();
                tile.name = "Snake Tile (" + position.x + ", " + position.y + ")";
            }
            else if (ladderPositions.Contains(position))
            {
                tile = Instantiate(ladderTilePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                LadderTile ladderTile = tile.GetComponent<LadderTile>();
                tile.name = "Ladder Tile (" + position.x + ", " + position.y + ")";
            }
            else{
                tile = Instantiate(tilePrefab, new Vector3(position.x, position.y, 0), Quaternion.identity);
                Tile Normaltile = tile.GetComponent<Tile>(); // Base tile type
                tile.name = "Normal Tile (" + position.x + ", " + position.y + ")";
            }
        }

    }
}
