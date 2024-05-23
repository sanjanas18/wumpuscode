using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    //popup for the damnge popups
    //variables
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        //sets it active, and to thecorresponding text
        popUpBox.SetActive(true);
        popUpText.text=text;
        animator.SetTrigger("pop");
        
    }
}