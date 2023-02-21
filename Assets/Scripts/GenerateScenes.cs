using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateScenes : MonoBehaviour
{
    //private int levelNumber = 0;
    //public Generate generateInstance;
    
    
    public void GenerateScene()//TODO: GENERATE SCENES WITH CODE
    {
        int loadSceneNumber = SceneManager.GetActiveScene().buildIndex +1;
        SceneManager.LoadScene(loadSceneNumber);
        GameManager.instance.sceneIsEmpty = true;
        Debug.Log(GameManager.instance.sceneIsEmpty.ToString());
    }

    

}
