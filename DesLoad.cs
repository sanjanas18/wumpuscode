using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DesLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMapTwo", 11.6f);
    }

    
    public void LoadMapTwo() {
        SceneManager.LoadScene("Map 2");
    }
    
}
