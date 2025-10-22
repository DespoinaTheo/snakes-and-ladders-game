using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int number; // Result of the dice roll

    // UI element representing different dice faces
    [SerializeField] private TMPro.TMP_Text diceNum;
    
    // Audio components for dice rolling sound
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;
     
    void Start()
    {
        diceNum.enabled = false; // Deactivates Dice text
    }

    public void DiceRoll()
    {
        diceNum.enabled = true; // Activates Dice text

        source.PlayOneShot(clip, 1f); // Dice rolling sound

        // Generate a random number between 1 and 6
        number = Random.Range(1, 7);
        
        Debug.Log($"Num= {number}.");

        // Enable the corresponding dice face based on the roll
        switch (number)
        {
            case 1:
                diceNum.text = "1";
                break;
            case 2:
                diceNum.text = "2";
                break;
            case 3:
                diceNum.text = "3";
                break;
            case 4:
                diceNum.text = "4";
                break;
            case 5:
                diceNum.text = "5";
                break;
            case 6:
                diceNum.text = "6";
                break;
        }
    }
}