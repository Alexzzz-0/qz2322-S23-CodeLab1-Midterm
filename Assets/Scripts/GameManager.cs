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
    
    public bool sceneIsEmpty = true;
    public bool fileIsEmpty = false;
    
    public GameObject tile;
    private float tileLength;
    public float startPositionX = -1f;
    public float startPositionY = -1f;

    public GameObject player;

    public int level;

    public int dustNumLeft;
    public int dustNumSolved;
    
    private void Start()
    {
        tileLength = tile.transform.GetComponent<Renderer>().bounds.size.x;
    }
    
    private const string generateSceneObject = "GenerateSceneHolder";
    private const string generateTileHolder = "GenerateTileHolder";

    void Generate()
    {
        if (fileIsEmpty == true)
        {
            GenerateASCIIFile();
            fileIsEmpty = false;
        }
        
        //
        if (sceneIsEmpty)
        {
            LevelLoader();
            gameMode = GameType.Clean;
        }
    }

    //two main functions that generate have: generate File, Map(UI)
    void GenerateASCIIFile()
    {
        transform.Find(generateTileHolder).GetComponent<GenerateTiles>().referenceFile(level);
    }

    void LevelLoader()
    {
        dustNumLeft = transform.Find(generateTileHolder).GetComponent<GenerateTiles>().InstantiateFromFile(level,tileLength);
        transform.Find("UIControllerHolder").GetComponent<UIController>().roomUIGenerate(level, dustNumLeft);
        sceneIsEmpty = false;
    }

    // //a class to hold the code for calling the class of generating tiles, for make an invoke
    // void GenerateTile()
    // {
    //     //transform.Find(generateTileHolder).GetComponent<GenerateTiles>().GenerateTile(1 + SceneManager.GetActiveScene().buildIndex,
    //         //startPositionX,startPositionY,tileLength);
    //         transform.Find(generateTileHolder).GetComponent<GenerateTiles>().referenceFile(level);
    //         Debug.Log(level.ToString());
    // }

    
    private const string playerControllerHolder = "PlayerControllerHolder";

    
    void Clean()
    {
        
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.S))
            {
                //Debug.Log(" detect player move ");
                transform.Find(playerControllerHolder).GetComponent<playerController>().MoveOrTurn(tileLength);
            }

            if (dustNumLeft == 0)
            {
                level++;
                fileIsEmpty = true;
            }
    }
    
    
    public void RoomUIUpdate()
    {
        transform.Find("UIControllerHolder").GetComponent<UIController>().roomUIUpdate(dustNumSolved, dustNumLeft);
    }

    void UnUsed(){}
    void Store(){}
}
