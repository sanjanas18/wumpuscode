using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//rotation script for player
//necessary to shoot
//overall goal: for player to  rotate the way the cursor is rotating
public class rotation : MonoBehaviour
{

    //publics
    public Rigidbody2D rb;
    public Camera cam;
    public float moveSpeed = 12f;

    //vectors
    Vector2 movement;
    Vector2 mousePos;

    
    //bools
    bool facingRight = true;
    

    // called once per frame
    void Update()
    {
        //movement of axes
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //every fram gets the position of the mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void start() {
        //camera angle set up at the beggining to be on top of the player
        GameObject.Find("Main Camera (1)").transform.position = new Vector3(-95, 0, 0);
    }

    void FixedUpdate()
    {
        //called a little later after update
        //gets where the mouse is (input.mousepos)
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        // rotating and looking
        Vector2 lookDir = mousePos - rb.position;
        
        //facing left, have the player flip
        if (Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg>=90 && Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg<=270 && !facingRight){
            Flip();

        //facing right, have the player face right
        //gets y coords, x coords, and sees if bool of facing right is true or not
        }else if (Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg<=90 && Mathf.Atan2(lookDir.y, lookDir.x)* Mathf.Rad2Deg>=270 && facingRight){
            Flip();
        }

        //otherwise just follow the cursor to a specified angle
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        
        rb.rotation=angle;
    }

    void Flip(){
        //simple invert the gameobject to flip and set faceright to false
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
