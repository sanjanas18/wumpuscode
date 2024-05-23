using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTitleScreen : MonoBehaviour
{
    //script to just load title screen
    //explicit and easy, no complications 
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(0);
    }

}
