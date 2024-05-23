using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WumpusBullet : MonoBehaviour
{

    public float damagePerBullet = 1f; //change this to assign DPB

    void Start ()
    {
        Invoke("DestroyAfterDelay", 1);
    }

    public void DestroyAfterDelay()
    {
        // automatically destroy the bullet after a while, useful because it won't overload the amount of bullets 
        // otherwise they just travel infinitely
        // you can put in here what happens if the bullet times out the travel

        // destroys the bullet
        Destroy(gameObject);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //on colluion with bullet
        GameObject collisionGameObject = collision.gameObject;
        Player playerComponent = collisionGameObject.GetComponent<Player>();

        //kill the player if it hits
        //or if hits wumpus or something, ignore the hit
        //else, just destroy the bullet 
        if(playerComponent != null) {
            playerComponent.GGs();
        }else if (collisionGameObject.name == "TestingWumpus"){
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        } else{
            Destroy(gameObject);
        }
    }
}
