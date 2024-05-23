using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to show a shield when the wumpus shoots at you
//should turn off when you click
//otherwise should shield you from bullet

//should be 100% good unless you turn
public class ShieldWhenShoot : MonoBehaviour
{   
    //publics
    public WumpusShooting2 yesOrNotShooting;
    public Rigidbody2D selfRigidbody;

    //shield and everything is off at first
    void Start()
    {
        DeActivateShield();
        UnFreezeAll();
    }

    // void OnCollisionEnter2D(Collision2D col){
    //     FreezeAll();
    //     Invoke("UnFreezeAll", 0.001f);
    // }

    // Update is called once per frame
    void Update()
    {
        //print(yesOrNotShooting.shooting.ToString());
        //if shooting, put the shield on for seven seconds
        if (yesOrNotShooting.shooting){
            ActivateShield();
            Invoke("DeActivateShield", 5.5f);
        } 
    }

    //sets the gameobject to be enabled and visible
    //colider takes damage
    void ActivateShield(){
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = true;
    }

    //sets above to off
    void DeActivateShield(){
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().GetComponent<Renderer>().enabled = false;
    }

    //constraints on shield

    void FreezeAll(){
        selfRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    void UnFreezeAll(){
        selfRigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
