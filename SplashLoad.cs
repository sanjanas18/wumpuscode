using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadStart", 4f);
    }

    public void loadStart() {
        SceneManager.LoadScene("Title Screen");
    }
}
