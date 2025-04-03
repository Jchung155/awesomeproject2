using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    //This script controls what happens on the Game Over screen
    //Currently, the only option is for the player to hit 'Space' and restart the game
    
    //Every frame, we check for player inputs
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //If the player hit space. . .
        if (Input.GetKeyDown(KeyCode.Space))
        {
       
            SceneManager.LoadScene("scene");
        }
    }
}
