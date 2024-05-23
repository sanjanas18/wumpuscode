//quick script to load the next popups for instruction
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//what loads the instructions for instruction scene
public class LoadSteps : MonoBehaviour
{
    // Start is called before the first frame update
    //gameobject signs
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject wumpus;
    
    //sets the arrows
    public GameObject arrowtwo;
    public void LoadOne() {
        one.SetActive(true);
    }
    //loads second sign
    public void LoadTwo() {
        one.SetActive(false);
        two.SetActive(true);
    }
    //loads third sign
    public void LoadThree() {
        two.SetActive(false);
        three.SetActive(true);
      //arrow for rocket to use it
        arrowtwo.SetActive(true);
    }
    //load fourth instruction sign that will say the wu,pus
    public void LoadFour() {
        three.SetActive(false);
        four.SetActive(true);
        //puts the wumpus there for player to battle
        //this wumpus is easy to beat
        wumpus.SetActive(true);
    }

    //loads the map scenes to select
    public void LoadMapScene() {
        
            SceneManager.LoadScene("MainGameScene");
        

        

     
    }
}
