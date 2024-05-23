using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//ui for unity import
using UnityEngine.UI;

//controls the choosing of what map you want to go to 
//green
//desert
//snow
//rock
//purple wonderland
public class MapChoose : MonoBehaviour
{
    //corresponding popups for each map 
    //map 1-5, green through purple
    public GameObject popup1;
    public GameObject popup2;
    public GameObject popup3;
    public GameObject popup4;
    public GameObject popup5;
    // Start is called before the first frame update
    //for an on pointer enter controlled in the inspector
    //shows the thing
    public void showThing()
    {
        //if the button is for map 1
        if(gameObject.tag.Equals("planet1")) {
        popup2.SetActive(false);
        popup3.SetActive(false);
        popup4.SetActive(false);
        popup5.SetActive(false);
        popup1.SetActive(true);
        //has it stay for a second to read then goes away
        Invoke("hideThing", 1.5f);
        
        }
        //similarly, for the rest of the planets
        if(gameObject.tag.Equals("planet2")) {   
        popup1.SetActive(false);
        popup3.SetActive(false);
        popup4.SetActive(false);
        popup5.SetActive(false);
        popup2.SetActive(true);
        Invoke("hideThing", 1.5f);
        
        }

        if(gameObject.tag.Equals("planet3")) {
        popup1.SetActive(false);
        popup2.SetActive(false);
      
        popup4.SetActive(false);
        popup5.SetActive(false);
        popup3.SetActive(true);
        Invoke("hideThing", 1.5f);
       
        }

        if(gameObject.tag.Equals("planet4")) {
        popup1.SetActive(false);
        popup2.SetActive(false);
        popup3.SetActive(false);
        
        popup5.SetActive(false);
        popup4.SetActive(true);
        Invoke("hideThing", 1.5f);
        
        }

        if(gameObject.tag.Equals("planet5")) {
        popup1.SetActive(false);
        popup2.SetActive(false);
        popup3.SetActive(false);
        popup4.SetActive(false);
       
        popup5.SetActive(true);
        Invoke("hideThing", 1.5f);
      
        }
        
    }

   
    //hides all the popups
    //called after a second
    public void hideThing()
    {
        popup1.SetActive(false);
        popup2.SetActive(false);
        popup3.SetActive(false);
        popup4.SetActive(false);
        popup5.SetActive(false);
    }
}
