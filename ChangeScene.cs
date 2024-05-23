using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class ChangeScene : MonoBehaviour
{
    //one of two scene changings

    //this one is to change to cut scenes and supplimental scenes

    // utility functions to load various scenes


    public void LoadScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    //classic loac random scene function
    //in future can use for a possible random map 
    public void LoadRandomScene() {
        Random rand = new Random();
        int roomNum = rand.Next(1,4);
        SceneManager.LoadScene("Map " + roomNum);
    }

//cut scene loading for each type
    public void LoadGrassCutscene() {
        SceneManager.LoadScene("GrassCutscene");
    }

    public void LoadSnowCutscene() {
        SceneManager.LoadScene("SnowCutscene");
    }

    public void LoaDesCutscene() {
        SceneManager.LoadScene("DesertCutscene");
    }

    public void LoadRockCutscene() {
        SceneManager.LoadScene("RockCutscene");
    }

    public void LoadPurpleCutscene() {
        SceneManager.LoadScene("PurpleCutscene");
    }
    
}