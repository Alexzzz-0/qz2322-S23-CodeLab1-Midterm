using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private Vector3 moveToPos;
    private Vector3 moveDis;
    public float speedMove;
    public float speedTurn;

    private void Update()
    {
        
    }

    public void Turn(playerController.playerDirection turnFace)
    {
        Debug.Log("Turn Listener!");
        
        int n = 0;
        int agle = 90;
        
        if (turnFace == playerController.playerDirection.left)
        {
            n = 0;
        }
        
        if (turnFace == playerController.playerDirection.up)
        {
            n = 1;
        }

        if (turnFace == playerController.playerDirection.right)
        {
            n = 2;
        }

        if (turnFace == playerController.playerDirection.down)
        {
            n = 3;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler( Vector3.forward *(agle * n % 360)), Time.deltaTime * speedTurn );
        
    }

    public void Move( float moveLength)
    {
        Debug.Log("Move Listener!");
        
        moveDis = transform.position + transform.rotation * Vector3.forward * moveLength;
        moveToPos = Vector3.Lerp(transform.position, moveDis, Time.deltaTime*speedMove);
        playerRb.MovePosition(moveToPos);
    }
}
