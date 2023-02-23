using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GenerateTiles : MonoBehaviour
{
    //these are the variables that control how many times of tiles are generated each level
    public int tileMaxX = 6;
    public int tileMaxY = 6;

    public GameObject tile;
    public GameObject dirt;
    public GameObject edge;

    //it is the variable that returns the player's start position to game manager script
    public float tileStartX;

    public void GenerateTile(int level, float startPositionX, float startPositionY, float tileLength)
    {
        //create parents for the generating objects
        GameObject tileParent = new GameObject("TileParent");
        GameObject dirtParent = new GameObject("DirtParent");
        GameObject WallParent = new GameObject("WallParent");
        
        for (int i = 0; i < tileMaxY * level; i++)
        {
            //set up how many blocks in this row 
            int rowLengthNumber = (int)Random.Range((tileMaxX * level) / 2, tileMaxX * level-2);
            //set up which block is the start of this row
            int leftBlankNumber = (int)Random.Range(1, tileMaxX * level - rowLengthNumber);
            
            //generate tiles
            for (int j = 0; j < rowLengthNumber; j++)
            {
                //generate the tile that can be played
                GameObject newTile = Instantiate(tile, tileParent.transform);
                newTile.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber + j),
                    startPositionY + i * tileLength);
                //generate the dirt at the same place
                GameObject newDirt = Instantiate(dirt, dirtParent.transform);
                newDirt.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber + j),
                    startPositionY + i * tileLength);
            }

            //generate the left tile
            GameObject leftEdge = Instantiate(edge, WallParent.transform);
            leftEdge.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber -1),
                startPositionY + i * tileLength);
            //generate the right tile
            GameObject rightEdge = Instantiate(edge, WallParent.transform);
            rightEdge.transform.position = new Vector3(startPositionX + tileLength * (rowLengthNumber + leftBlankNumber),
                startPositionY + i * tileLength);
            
            //generate the up wall
            if ( i == 0 || i == tileMaxY * level - 1)
            {
                //row 0: make a line upon it
                //row last: make a line below it
                int q = 1;
                if (i == 0)
                {
                    q = -1;
                }
                
                //the code for generating the up and down wall
                for (int j = 0; j < rowLengthNumber + 2; j++)
                {
                    GameObject upEdge = Instantiate(edge, WallParent.transform);
                    upEdge.transform.position = new Vector3(startPositionX + tileLength * (leftBlankNumber + j -1),
                        startPositionY +( i + q ) * tileLength);
                }
            }

            //rreturn the tile's startX to the GM so that it know where to put the player
            if (i == 0)
            {
                tileStartX = startPositionX + tileLength * leftBlankNumber;
            }
        }
    }
    
    
    public void GeneratePlayer(float startPositionX, float startPositionY, GameObject player)
    {
        GameObject theplayer = Instantiate(player);
        theplayer.transform.position = new Vector3(startPositionX, startPositionY);
    }
}
