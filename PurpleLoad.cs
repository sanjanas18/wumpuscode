using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurpleLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMapFive", 11.6f);
    }

     public void LoadMapFive() {
        SceneManager.LoadScene("Map 5");
    }
}
