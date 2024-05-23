using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInput : MonoBehaviour
{

    string answer;
    string str;
    // gameobjects
    public GameObject answerbox;
    public GameObject question;
    public GameObject player;
    public GameObject questionText;
    public GameObject rightAnswer;
    public GameObject wrongAnswer;
    public GameObject canvas;
    // count of right and wrong answers
    private int wrong = 0;
    private int right = 0;
    
    // disappear and hide the answer popups
    void Start()
    {
        answerbox.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        wrongAnswer.SetActive(false);
        rightAnswer.SetActive(false);
    }

    // set the current answer
    public void SetAnswer(string a) {
        answer = a;
    }

    // stop hiding
    public void Appear() {
        answerbox.GetComponent<RectTransform>().localScale = new Vector3(2,2,2);
    }

    // hide
    public void hide() {
        answerbox.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    // display the "correct" popup then disappear after a few seconds
    IEnumerator Waitv1() {
        wrongAnswer.SetActive(false);
        rightAnswer.SetActive(true);
        yield return new WaitForSeconds(2);
        rightAnswer.SetActive(false);
    }

    // display the "incorrect" popup then disappear after a few seconds   
    IEnumerator Waitv2() {
        rightAnswer.SetActive(false);
        wrongAnswer.SetActive(true);
        yield return new WaitForSeconds(2);
        wrongAnswer.SetActive(false);
    }

    // get impact and respond depending on if the player is right
    public void GetInput(string s) {
        str = s;
        if (str.ToLower().Equals(answer.ToLower())) {
            right += 1;
            Debug.Log("right");
            StartCoroutine(Waitv1());
            //popup for right
        } else {
            wrong += 1;
            Debug.Log("wrong");
            StartCoroutine(Waitv2());
            //popup for wrong
        }
        if (wrong > 2) {
            Debug.Log("You died");
            questionText.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            answerbox.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            player.GetComponent<Player>().GGs();
        } 
        if (right >= 3) {
            player.transform.localScale = new Vector3(35, 35, 35);
            player.transform.GetChild(1).gameObject.SetActive(true);
            player.transform.GetChild(2).gameObject.SetActive(true);
            canvas.SetActive(false);
            questionText.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            answerbox.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0); 
            right = 0;
            wrong = 0;
        }
        question.GetComponent<Question>().DisplayQuestion();
        
    }
}
