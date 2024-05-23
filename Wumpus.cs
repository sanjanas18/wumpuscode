using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wumpus : MonoBehaviour
{
    public float startHP = 30f;
    public float currentHP;

    public GameObject WumpusSelf;

    public GameObject dieParticleEffect; //the particle for dying wumpus
    public GameObject ActivatePlayerTrail; //the playertrail instantiated upon ded
    public GameObject DeactivatePlayerTrail1; //the playertrail deleted upon ded
    public GameObject DeactivatePlayerTrail2; //the playertrail deleted upon ded
    public GameObject player;

    private int shootingTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        //start hp and current hp
        currentHP = startHP;
        // TakeDamage(currentHP);
    }

    public void TakeDamage(float damage)
    {
        currentHP = currentHP - damage; // wump takes damage

        //check if wump is killed
        if (currentHP <= 0f)
        {
            Dead(); //calls the function to cause the wump to die
        } else if (currentHP <= startHP/2f && shootingTimes == 0){
            WumpusSelf.GetComponent<WumpusShooting2>().ShootBegin(); //start shooting when below half hp
            shootingTimes = 1;
        } else if (currentHP <= startHP/4f && shootingTimes == 1){
            WumpusSelf.GetComponent<WumpusShooting2>().ShootBegin(); //start shooting when below half hp
            shootingTimes = 2;
        }
    }

    //if wumpus ded, player wins
    void Dead(){
        player.GetComponent<Player>().win();
        if (dieParticleEffect != null){
            //small particle effects that stay for 5 seconds before win screen comes
            ActivatePlayerTrail.GetComponent<ParticleSystem>().Play();
            ParticleSystem.EmissionModule aem = ActivatePlayerTrail.GetComponent<ParticleSystem>().emission;  //cause the winning particle to emit
            aem.enabled = true;

            
            DeactivatePlayerTrail1.GetComponent<TrailRenderer>().enabled = false; //turn off the normal trail
            DeactivatePlayerTrail2.GetComponent<TrailRenderer>().enabled = false; //turn off the normal trail
        }

        Destroy(gameObject); //destroy wump
        Instantiate(dieParticleEffect, transform.position, Quaternion.identity); //create death explosion

        //call a ded popup
        DamagePopup.Create(transform.position, (string) "Ded \n Not big \n soup rice");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        // damage calculation
        if (collisionGameObject.GetComponent<Player>() != null)
        {
            collisionGameObject.GetComponent<Player>().GGs();
        }
    }

    //if the wumpus enters a new room (because of wumpus ai)
    public void OnTriggerEnter2D(Collider2D col) {
        //put this rooms name as wumpus
        //put the surrounding rooms arround it (two random surrounding rooms) to have the warning of wumpus
        col.tag = "Wumpus";
        GameObject game = GameObject.Find("RoomTriggers");
        HazardSpawning script = game.GetComponent<HazardSpawning>();
        GameObject[] rooms = script.rooms;
        for (int i = 0; i <= 27; i++) {
            if (rooms[i].name.Equals(col.name)) {
                rooms[i-1].tag = "WumpWarn";
                rooms[i + 1].tag = "WumpWarn";
                rooms[i+3].tag = "WumpWarn";
                
            }
        }
    }
    
}
