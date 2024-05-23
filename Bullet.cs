using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    [SerializeField] public float damagePerBullet = 10f; //change this to assign DPB
    //called when game is fully loaded
    void Start ()
    {
        Invoke("DestroyAfterDelay", 3);
    }

    public void DestroyAfterDelay()
    {
        // automatically destroy the bullet after a while, useful because it won't overload the amount of bullets 
        // otherwise they just travel infinitely
        // you can put in here what happens if the bullet times out the travel

        // destroys the bullet
        Destroy(gameObject);
    }
    //double damage method for shop
    public void doubleDamage() {
        damagePerBullet = 15f;
    }

    //on collision with bullet
    //each object that can be hit has a rigidbody that can detect this collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ignoring if the player is the one it is collided with
        //dont want player to die
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "Player") {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        //override player collision
        //anything but player can be shot
        if (collisionGameObject.name != "Player")
        {
            //gets wumpus reducing health component of wumpus game object
            //reference wumpus script
            Wumpus wumponent = collisionGameObject.GetComponent<Wumpus>();

            // damage calculation
            if (wumponent != null)
            {
                wumponent.TakeDamage(damagePerBullet);

                //call a damage popup
                DamagePopup.Create(transform.position, "-5");
            }


            // destroys the bullet
            Destroy(gameObject);
        }
    }

}
