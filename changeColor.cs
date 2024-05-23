using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//simple  script to change the color the text in the loading/title screen
public class changeColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Text myText;

    void Start()
    {
        //ggetting text component from text 
        myText = GetComponentInChildren<Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //changing tex to white on pointer enter
        myText.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //else keep it grey
        myText.color = Color.grey;
    }

}