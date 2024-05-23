using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// wumpus ai that pounces and comes towards player if it sees it

public class WumpusAI : MonoBehaviour
{
    //variables
    //globals
    public float SPEED = 200f;
    public float pounceDistance = 100f;

    private Vector3 startingPosition;
    private Vector3 playerPosition;

    private Vector3 moveVector;
    public static Queue<Vector3> pastVectorMovement = new Queue<Vector3>();

    private float differenceX;
    private float differenceY;
    private float hypoteneuseXY;

    private float ratioXToTotal; // stores the ratio of x movement to total movement
    private float distance;

    public GameObject player;
    public Rigidbody2D wumpusrb;

    public static bool chasePlayer = true; //for a future condition to replace
    public static bool pouncePlayer = false; 
    public float recogDistance = 300f;

    public bool chasing = false;

    public bool unstunned = true;

    // Start is called before the first frame update
    void Start() 
    {
        //starting position of all
        startingPosition = transform.position;
        playerPosition = player.GetComponent<Player>().currentPos();
        //starts movement couroutine
        StartCoroutine(MovementCoroutine());
    }

    void Update()
    {
        StartCoroutine(MovementCoroutine());
    }

    IEnumerator MovementCoroutine()
    {   
        //keeps tabs on player posution
        playerPosition = player.GetComponent<Player>().currentPos();
        //calculates distance between wumpus (self) and p,ayers position
        distance = Vector3.Distance(transform.position, playerPosition);

        //using these values to later valculate the hypotenuse
        differenceX = playerPosition.x - transform.position.x;
        differenceY = playerPosition.y - transform.position.y;

        //idk if there is a method so i just pythag here
        hypoteneuseXY = (float) Math.Sqrt(differenceX * differenceX + differenceY * differenceY);

        differenceX = differenceX / hypoteneuseXY;
        differenceY = differenceY / hypoteneuseXY;
        //creates a possible new target to move towards using hypotenuse
        moveVector = new Vector3(differenceX, differenceY, 0);
        //if the wumpus is chasing the player and has ability to move
        if (chasing && unstunned){
            //go towards calculated position
            pastVectorMovement.Enqueue(moveVector);
            //AND, if it is chasing the player
            if (chasePlayer){
                //if the plaer is within the predetermined pounce distance (don't want wumpus to be able to pounce on top of player wuickly)
                if (distance < pounceDistance){
                    //wait for a sec, then pounce
                    pastVectorMovement.Dequeue();
                    yield return new WaitForSeconds(5f);
                    wumpusrb.MovePosition(transform.position + moveVector * SPEED * Math.Min(Time.deltaTime, 0.03f)*4);
                    Debug.Log("POUNCE");

                    //pastPosition.Dequeue();
                }else{
                    //or else just slowly move the wumpus
                    wumpusrb.MovePosition(transform.position + moveVector * SPEED * Math.Min(Time.deltaTime, 0.03f));

                    //pastPosition.Dequeue();
                }
                
            }
        }
        //if it IS stunned
        //go a bit slower
        if (!unstunned){
            wumpusrb.MovePosition(transform.position - moveVector * SPEED * Math.Min(Time.deltaTime, 0.03f)*6);
        }

        //when chasing = true
        //when distance of hyp is smaller than recog distance (300f)
        if (hypoteneuseXY < recogDistance){
            chasing = true;
        }
        
    }

}