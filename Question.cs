using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;
using System.IO;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    // list of all questions and answers
    ArrayList questions;
    ArrayList answers;
    // gameobjects
    public GameObject answer;
    public GameObject question;
    public GameObject player;
    private string currAnswer;

    // fill arraylists with questions and answers from external file
    void Start()
    {    
        //makes sure question is hidden
        question.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
        //where trivia gets all the questions from
        string path = "Assets/trivia.txt"; // change with text file is added
        questions = new ArrayList();
        answers = new ArrayList();
        //reads file
        using (StreamReader file = new StreamReader(path)) {  
            int counter = 0;  
            string line;  
            while ((line = file.ReadLine()) != null) {  
                if (counter % 2 == 0) {
                    questions.Add(line);
                } else {
                    answers.Add(line);
                }
            counter++;  
            }  
        } 
    }

    // disspear while not in trivia room
    public void hide() {
         question.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
    }

    // get the current answer for the current question
    public string getAnswer() {
        return currAnswer;
    }

    // choose a random question, get its answer, and appear
    public void DisplayQuestion() {
        //shows the question
        question.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        Random rand = new Random();
        //uses random import to randomly choose a number
        int idx = rand.Next(questions.Count);
        currAnswer = (string) answers[idx];
        //sets the correct answer which text input will check
        answer.GetComponent<TextInput>().SetAnswer((string) answers[idx]);
        question.GetComponent<Text>().text = (string) questions[idx];
        
    }
    
}
