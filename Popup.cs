using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    
    //simple thing to show a gameobject overlay
    //and get rid of a overlay
    //used for hazards and things like fog bats
    public GameObject popper; 
    
    public void pop() {
        popper.gameObject.SetActive(false); 

    }
}
