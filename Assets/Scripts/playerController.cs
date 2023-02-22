using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    /// Detect to go or to turn
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// make an enum array to store the information of the player's current facing direction
    /// use the playerFace to compare with the command currently received
    /// if it is the same, move; or turn to that direction
    public enum playerDirection
    {
        left,
        right,
        up,
        down
    }

    private playerDirection playerFace = playerDirection.right;

    private GameObject player;
    
    public void MoveOrTurn(float moveLength)
    {
        player = GameObject.FindWithTag("Player");

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerFace == playerDirection.left)
            {
                Debug.Log("Move Left!");
                player.GetComponent<player>().Move(moveLength);
            }
            else
            {
                Debug.Log("Turn Left!");
                playerFace = playerDirection.left;
                player.GetComponent<player>().assignTurnFace(playerFace);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerFace == playerDirection.right)
            {
                Debug.Log("Move Right!");
                player.GetComponent<player>().Move(moveLength);
            }
            else
            {
                Debug.Log("Turn Right!");
                playerFace = playerDirection.right;
                player.GetComponent<player>().assignTurnFace(playerFace);
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerFace == playerDirection.up)
            {
                Debug.Log("Move Up!");
                player.GetComponent<player>().Move(moveLength);
            }
            else
            {
                Debug.Log("Turn Up!");
                playerFace = playerDirection.up;
                player.GetComponent<player>().assignTurnFace(playerFace);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerFace == playerDirection.down)
            {
                Debug.Log("Move Down!");
                player.GetComponent<player>().Move(moveLength);
            }
            else
            {
                Debug.Log("Turn Down!");
                playerFace = playerDirection.down;
                player.GetComponent<player>().assignTurnFace(playerFace);
            }
        }
    }
    
}
