using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] boulders; // Reference to the boulder GameObjects
    public Transform dropZone; // Reference to the drop zone's Transform component
    public float power; // The current power of the rocket
    public float maxPower; // The maximum power of the rocket

    private bool gameEnded;  // Flag indicating if the game has ended

    void Update()
    {
        if (power <= 0)
        {
            // reset the game
        }

        if (!gameEnded)
        {
            bool allInDropZone = true;
            foreach (GameObject boulder in boulders)
            {
                if (boulder.transform.position != dropZone.position)
                {
                    allInDropZone = false;
                    break;
                }
            }

            if (allInDropZone)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        Debug.Log("Congratulations! All boulders have been successfully moved to the drop zone. Game Over!");
    }
}
