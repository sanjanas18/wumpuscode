using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SnowLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMapThree", 11.6f);
    }

     public void LoadMapThree() {
        SceneManager.LoadScene("Map 3");
    }
}
