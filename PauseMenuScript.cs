using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        //menu should be set active on start and anytime that is not currently called
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        //escape key = pause menu is true
        //if is paused, and esc is clicked again, resumed
        //or else pause it
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            } else{
                PauseGame();
            }
        }
    }
    //pause method
    //puts pause to true and shows pause menu
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    //resume game
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    //quite game
    public void QuitGame(){
        //Application.Quit();
        SceneManager.LoadScene("Title Screen");
    }
}
