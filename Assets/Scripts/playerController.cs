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
                player.GetComponent<player>().Turn(playerFace);
                playerFace = playerDirection.left;
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
                player.GetComponent<player>().Turn(playerFace);
                playerFace = playerDirection.right;
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
                player.GetComponent<player>().Turn(playerFace);
                playerFace = playerDirection.up;
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
                player.GetComponent<player>().Turn(playerFace);
                playerFace = playerDirection.down;
            }
        }
    }
    
}
