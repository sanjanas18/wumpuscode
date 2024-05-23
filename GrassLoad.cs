using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrassLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMapOne", 11.9f);
    }

    
    public void LoadMapOne() {
        SceneManager.LoadScene("Map1 Real");
    }
}
