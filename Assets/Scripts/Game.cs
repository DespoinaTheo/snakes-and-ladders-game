using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    // UI text variables
    [SerializeField] private TMPro.TMP_Text StartGametxt;
    [SerializeField] private TMPro.TMP_Text QuitGametxt;
    [SerializeField] private TMPro.TMP_Text VictoryTxt;
    [SerializeField] private TMPro.TMP_Text turnTxt;
   


    // Game Board reference
    public GameObject Board;

    // Game state variables
    private bool gameStarted = false;
    private bool victory = false;

    // Players' references
    public Player player1;
    public Player player2;
    public Player turn;

    // Dice reference
    public GameObject Dice;

    // Powerup- Enemy flags
    public bool extraRollActivated;
    public bool turnLossActivated;

    // Round tracking
    public static int round;

    // Audio
    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip clip;

    // Singleton instance of the Game class
    public static Game Instance { get; private set; }

    public Game()  // Constructor
    {
        Instance = this;
    }
    void Start()
      {
        // Initialize UI elements
        StartGametxt.enabled = true;
        QuitGametxt.enabled = true;
        VictoryTxt.enabled = false;
        turnTxt.enabled = false;


        round = 0; // Initialize the round count
    }

    void Update()
    {
        // Start game if "space" is pressed
        if (Input.GetKeyDown("space") && !gameStarted && !victory){
            //Directions.gameObject.SetActive(false);
            StartGame();   
        }
        // Quit game if "escape" is pressed
        if (Input.GetKeyDown("escape") && gameStarted && !victory){
            Invoke("ExitGame", 1f);
        }
        // Player rolls the dice and takes a turn when 'd' is pressed
        if (gameStarted && !victory && Input.GetKeyDown("d"))
        {
            turnTxt.enabled = true;
            if (!extraRollActivated)
            {
                if (turnLossActivated) // if turnLoss is activated then extraRoll gets activated so next player playes twice
                {
                    extraRollActivated = true;
                }
                round+=1; // Increase the round count
                turnLossActivated = false;
            }
            else
            {
                extraRollActivated = false;
            }
            // Determine whose turn it is based on the round number
            if (round%2 !=0)
            {
                turn = player1;
                turnTxt.text = "Turn: Player 1";
                turnTxt.color = Color.magenta;
                newTurn(); 
            }
            else if (round%2 ==0)
            {
                turn = player2;
                turnTxt.text = "Turn: Player 2";
                turnTxt.color = Color.green;
                newTurn();
            }       
        }
    } 

    void StartGame()
    {    
        gameStarted = true;

        // Get Board script component and initialize the board
        Board boardScript = Board.GetComponent<Board>();
        boardScript.BoardBuild();

        StartGametxt.enabled = false;

    }
    
    void newTurn()
    {
        // Get Dice script and roll the dice for the current player
        Dice diceScript = turn.Dice.GetComponent<Dice>();
        diceScript.DiceRoll();

        turn.Movement(); // Move player based on dice roll
        VictoryCheck(); // Check if the player won
    }

    public void ActivateExtraRoll()
    {
        extraRollActivated = true;  // Power-up activated, prevents round change
    }
    public void ActivateLoseTurn()
    {
        turnLossActivated = true; // Turn loss activated
    }

    void ExitGame()
    {    
        SceneManager.LoadScene("GameScene"); // Game gets reload
    }
    void VictoryCheck()
    {
        // Check if the player has reached the victory position
        if (turn.position.x == -4.5f && turn.position.y == 4.5)
        {
            turnTxt.enabled = false;
            VictoryTxt.enabled = true;
            if (turn == player1)
            {
                VictoryTxt.text = "Winner: Player 1";
                VictoryTxt.color = Color.magenta;
            }
            else
            {
                VictoryTxt.text = "Winner: Player 2";
                VictoryTxt.color = Color.green;
            }
            victory = true;
            source.PlayOneShot(clip, 1f);

            Invoke("ExitGame", 5f); // Restart game after delay
        }
    }
}