using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityOn : MonoBehaviour
{
    //simple set active script
    //used for many gamobjects
    //opposite of 'popper' script
    public GameObject itemSelf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemSelf.SetActive(true);
    }
}
