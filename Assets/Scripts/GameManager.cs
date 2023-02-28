using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    //make the game's state: 5 states
    public enum GameType
    {
        Default,
        Generate,
        Clean,
        UnUsed,
        Store
    }

    public GameType gameMode = GameType.Default;

    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            gameMode = GameType.Clean;
        }
        
        switch (gameMode)
        {
            case GameType.Generate:
                Generate();
                break;
            case GameType.Clean:
                Clean();
                break;
            case GameType.UnUsed:
                UnUsed();
                break;
            case GameType.Store:
                Store();
                break;

        }
    }

    // private bool sceneIsEmpty = true;
    // public bool SceneIsEmpty
    // {
    //     get { return sceneIsEmpty; }
    //     set { sceneIsEmpty = value; }
    // }
    public bool sceneIsEmpty = true;
    public bool playerIsEmpty = false;
    
    public GameObject tile;
    private float tileLength;
    public float startPositionX = -1f;
    public float startPositionY = -1f;

    public GameObject player;

    public int level;
    
    private void Start()
    {
        tileLength = tile.transform.GetComponent<Renderer>().bounds.size.x;
    }
    
    /// Generate caller
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    private const string generateSceneObject = "GenerateSceneHolder";
    private const string generateTileHolder = "GenerateTileHolder";

    void Generate()
    {
        //if....load new scene
        if (Input.GetKeyDown(KeyCode.H))//TODO: setup the transition point
        {
            transform.Find(generateSceneObject).GetComponent<GenerateScenes>().GenerateScene();
        }

        //if....generate tiles
        if (sceneIsEmpty)
        {
            //bc the scene loads too slow, we should put a small delay at generating the tiles
            //or when the scene is loading, the tile has been generated and when get to the new scene, it is empty
            Invoke("GenerateTile",.1f);
            sceneIsEmpty = false;
            playerIsEmpty = true;
        }

        if (playerIsEmpty == true)
        {
            Invoke("GeneratePlayer", .2f);
            playerIsEmpty = false;
        }
    }

    //a class to hold the code for calling the class of generating tiles, for make an invoke
    void GenerateTile()
    {
        //transform.Find(generateTileHolder).GetComponent<GenerateTiles>().GenerateTile(1 + SceneManager.GetActiveScene().buildIndex,
            //startPositionX,startPositionY,tileLength);
            transform.Find(generateTileHolder).GetComponent<GenerateTiles>().GenerateTileNew(level);
            Debug.Log(level.ToString());
    }

    
    private const string playerControllerHolder = "PlayerControllerHolder";

    
    void Clean()
    {
        
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log(" detect player move ");
                transform.Find(playerControllerHolder).GetComponent<playerController>().MoveOrTurn(tileLength);
            }
        


    }
    void UnUsed(){}
    void Store(){}
}
