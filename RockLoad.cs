using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RockLoad : MonoBehaviour
{
   void Start()
    {
        Invoke("LoadMapFour", 11.6f);
    }

    public void LoadMapFour() {
        SceneManager.LoadScene("Map 4");
    }
}
