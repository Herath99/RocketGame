using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public GameObject powerDisplay; // Reference to the UI element that shows the remaining power
    public GameObject scoreDisplay; // Reference to the UI element that shows the score
    public GameObject healthDisplay; // Reference to the UI element that shows the health
    public GameObject progressDisplay; // Reference to the UI element that shows the progress

    public float power; // The current power of the rocket
    public int score; // The current score of the player
    public int health; // The current health of the player
    public float progress; // The current progress of the game

    void Update()
    {
        powerDisplay.GetComponent<Text>().text = "Power: " + power;
        scoreDisplay.GetComponent<Text>().text = "Score: " + score;
        healthDisplay.GetComponent<Text>().text = "Health: " + health;
        progressDisplay.GetComponent<Text>().text = "Progress: " + progress + "%";
    }
}

