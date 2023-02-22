using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Mathematics;
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
        //transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, agle * n), Time.deltaTime * speedTurn ); 
    }
    int n = 0;
    
    public void assignTurnFace(playerController.playerDirection turnFace)
    {
        //Debug.Log("Turn Listener!");
        
        if (turnFace == playerController.playerDirection.left)
        {
            n = 2;
        }
        
        if (turnFace == playerController.playerDirection.up)
        {
            n = 1;
        }

        if (turnFace == playerController.playerDirection.right)
        {
            n = 0;
        }

        if (turnFace == playerController.playerDirection.down)
        {
            n = 3;
        }

        StartCoroutine(Turn());
        //transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, agle * n), Time.deltaTime * speedTurn );
    }

    IEnumerator Turn()
    {
        Debug.Log("Turn listener!");
        int agle = 90;
        
        for (float i = 0; i <= 1; i +=Time.deltaTime)
        {
            Debug.Log(i.ToString());
            //transform.rotation = Quaternion.Euler(Vector3.forward * (agle * n * (i  / speedTurn)));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.forward * (agle * n)), i);
            yield return null;
        }
        
        //this one works
        //transform.rotation = Quaternion.Euler(Vector3.forward * (agle * n ));
    }
    
    
    public void Move( float moveLength)
    {
        //Debug.Log("Move Listener!");
        
        // moveDis = transform.position + transform.rotation.normalized * Vector3.forward * moveLength;
        // moveToPos = Vector3.Lerp(transform.position, moveDis, Time.deltaTime*speedMove);
        // playerRb.MovePosition(moveToPos);
        // //playerRb.MovePosition(moveDis);
        
    }
}
