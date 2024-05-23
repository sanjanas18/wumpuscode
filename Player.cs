using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    // public variables
    public float moveSpeed = 12f;
    public float characterSize;
    public GameObject popper; 
    public GameObject wumpPopper;
    public GameObject mainRoom;
    public GameObject batWarn;
    public GameObject canvas;
    public GameObject coinCount;
    public GameObject deathScreen;
    public GameObject physicalTextBox;
    public GameObject scoreText;
    public Rigidbody2D rb;
    public Camera cam;
    public GameObject question;
    public GameObject textinput;
    public GameObject rocket;
    public GameObject dieParticleEffect;
    public static bool isDead = false;
    public GameObject winScreen;
    public GameObject scoreText2;
    public GameObject wumpus;
    public GameObject fog;
    public GameObject bats;
    public GameObject parentCoin;
    
    
    // private variables
    private int score;
    private int coins;
    
    // Vectors
    Vector2 movement;
    Vector2 mousePos;
    Vector3 currRoom;
    
    // Initialization
    // everything at 0 or starting value
    void Start() {
        score = 100;
        coins = 0;
        coinCount.GetComponent<Text>().text = "Coins: " + coins;
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // increase speed method for shop
    public void addSpeed(float ms) {
        moveSpeed += ms;
        Debug.Log(moveSpeed);
    }

    // method to see if coin subtraction > 0
    public bool canSubtract(int n) {
        return coins-n >= 0;
    }

    // subtracts coins method if method above is valid
    public void subtractCoins(int n) {
        coins -= n;
    }

    // public get coinds
    public int getNumCoins() {
        return coins;
    }


    // called once per frame
    void FixedUpdate()
    {
        // moving function every frame if player is not dead
        if (!isDead)
        {
            // moving
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            rb.MovePosition(transform.position + m_Input * moveSpeed * Time.deltaTime);

            // Flipping
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0){
                characterScale.x = characterSize;
            }
            if (Input.GetAxis("Horizontal") > 0){
                characterScale.x = -characterSize;
            }

            transform.localScale = characterScale;

            
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        } 

    }

    // returning current position of player
    public Vector3 currentPos(){
        return transform.position;
    }

    // trigger management of entering special rooms or colliding with something
    public void OnTriggerEnter2D(Collider2D col) {
        // if player enters special room, display the question and the textbox
       
        // camera changes position to room, every new room. screen for coins first
        if (!(col.tag.Equals("coins"))) {
            cam.transform.position = col.gameObject.transform.position;
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -23);
            score--;
        }
        
        // if a warning, put a popup that will auto disable after a second
        if (col.tag.Equals("warn")) {
            // Debug.Log("warn");
            popper.SetActive(true);
            Invoke("setFalse", 1.2f);
            // col.tag = "Untagged";
        }

        if (col.tag.Equals("fog")) {
            // Debug.Log("warn");
            fog.SetActive(true);
             Invoke("setFalse", 7f);
            // col.tag = "Untagged";
        }

        // if the room is meant to be a pit, display trivia, text entry, get rid of player
        // also popup the trivia background, hid rocket, and make the place not be a pit anymore
        if (col.tag.Equals("Pit")) {
            question.GetComponent<Question>().DisplayQuestion();
            textinput.GetComponent<TextInput>().Appear();
            // trivia background
            canvas.SetActive(true);
            // setting the player to not be there
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            col.tag = "Untagged";
            // place not a pit anymore
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -23);
            string room = col.name;
            mainRoom.GetComponent<HazardSpawning>().Untag(room);
            rocket.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
            Debug.Log(textinput.GetComponent<RectTransform>().localScale);
            // Debug.Log("Estoy en Room");
        } 

        // transport to random room for bats
        if (col.tag.Equals("Bats")) {
            bats.SetActive(true);
            Invoke("setFalse", 2f);
            int rand = UnityEngine.Random.Range(1,28);
            GameObject game = GameObject.Find("RoomTriggers");
            // gets list of all of the rooms from the hazard spawning and room setting up script
            HazardSpawning script = game.GetComponent<HazardSpawning>();
            GameObject[] rooms = script.rooms;
            GameObject randomroom = rooms[rand];
            // moving player randomly there
            gameObject.transform.position = new Vector3(randomroom.transform.position.x, randomroom.transform.position.y, 5);
           
            // setting a popup that says that player has been moved that will turn off
            if(!bats.activeInHierarchy.Equals(false)) {
                batWarn.SetActive(true);
                Invoke("setFalse", 1.2f);
            }
            
            mainRoom.GetComponent<HazardSpawning>().Untag(randomroom.name);
            col.tag = "Untagged";
        }

        // if it encounters the wumpus, make that already known to the game
        if (col.tag.Equals("Wumpus")) {
            col.gameObject.tag = "Untagged";
        }

        // if there is a wumpus warning, show a popup
        if (col.tag.Equals("WumpWarn")) {
            wumpPopper.SetActive(true);
            Invoke("setFalse", 1.2f);
            col.tag = "Untagged";
        }

        // or else, everything is hidden
         else {
            question.GetComponent<Question>().hide();
            textinput.GetComponent<TextInput>().hide();
            rocket.GetComponent<RectTransform>().localScale = new Vector3((float) 0.3, (float) 0.3, (float) 0.3);
            gameObject.SetActive(true);
        }
    }

    // setting everything off after a second
    void setFalse(){
        popper.SetActive(false);
        wumpPopper.SetActive(false);
        batWarn.SetActive(false);
        fog.SetActive(false);
        bats.SetActive(false);
    }    
    
    // killing code
    public void GGs() { 
        // call a damage popup
        score -= 50;
        string path = "Assets/Scripts/Scores.txt";
        StreamWriter writer = new StreamWriter(path, true);
        // write score to score log
        writer.WriteLine(score);
        writer.Close();
        sortScores();
        deathScreen.SetActive(true);
        Destroy(gameObject);
        Destroy(wumpus);
        Destroy(parentCoin);
        // make a cool particle effect
        DamagePopup.Create(transform.position - new Vector3(300, 0, 0), "You died!! \n Your score: 0");
        Instantiate(dieParticleEffect, transform.position, Quaternion.identity); //create death explosion
        isDead = true;
    }

    // show the win screen and write the players score to the score log
    public void wait() {
        winScreen.SetActive(true);
        string path = "Assets/Scripts/Scores.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(score);
        writer.Close();
        sortScores();
    }

    public void win() {
        // let the player celebrate before showing the win screen
        Invoke("wait", 5f);
    }

    // look through scores log and find player's rank
    public void sortScores() {
        string path = "Assets/Scripts/Scores.txt";
        string[] lines = File.ReadAllLines(path);
        int[] allScores = new int[lines.Length];
        for(int i = 0; i < lines.Length; i++) {
            allScores[i] = int.Parse(lines[i]);
        }
        Array.Sort(allScores);
        Array.Reverse(allScores);
        int place = Array.IndexOf(allScores, score) + 1;
        scoreText2.GetComponent<Text>().text = "Your score: " + score + "\n" + "Your rank: " + place + " out of " + allScores.Length;
        scoreText.GetComponent<Text>().text = "Your score: " + score +  "\n" + "Your rank: " + place + " out of " + allScores.Length;
        string result = string.Join(", ", allScores);
    }
}



