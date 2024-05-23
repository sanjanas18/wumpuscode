using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//scene loading class for all major scenes
//all maps come through here, title screen
public class SceneLoader : MonoBehaviour
{
    

    

    void Start() {
        //empty start function, take time to load
        
    }
    //start game function
    public void stateGame()
    {
        SceneManager.LoadScene("Game");
    }

    //loads the next scene in the build index. helpful when we dont need to specify by name what scene
    public void LoadNextScene() {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
       SceneManager.LoadScene(currentSceneIndex + 1);
   }

    //allows you to leave the window in which full screen game will operate
   public void QuitGame() {
       Application.Quit();
       
   }

    //loads first scene in index (title)
   public void LoadInitialScene() {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
       SceneManager.LoadScene(0);
   }

    //credita
    public void LoadCreditScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Credits");
    }
    //map selection scene
    public void LoadMapScene() {
        
            SceneManager.LoadScene("MainGameScene");
        

     
    }

    //remaining maps

    public void LoadMapThree() {
        SceneManager.LoadScene("Map 3");
    }
    public void LoadMapTwo() {
        SceneManager.LoadScene("Map 2");
    }

    

    public void LoadMapFour() {
        SceneManager.LoadScene("Map 4");
    }

     public void LoadMapFive() {
        SceneManager.LoadScene("Map 5");
    }
    public void LoadMapOne() {
        SceneManager.LoadScene("Map1 Real");
    }

    //inatructions scene
    public void LoadInstructions() {
        SceneManager.LoadScene("Instructions");
    }

}
