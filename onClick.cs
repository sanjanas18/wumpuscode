using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onClick : MonoBehaviour
{
    //on click change text
    private Text myText;
    public string orignal;
    public string changed;
    public void changeText()
    {
        //change all the text if it isnt changed
        //if not keep it to the original
        //use in title and in gamw
        myText = GetComponentInChildren<Text>();
        if (myText.text == changed)
        {
            myText.text = orignal;
        }
        else
        {
            myText.text = changed;
        }

    }
}
