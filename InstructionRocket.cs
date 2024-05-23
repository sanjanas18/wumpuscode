using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//dummed down version of the rocket
//goes to only a specific room
public class InstructionRocket : MonoBehaviour
{
     // gameobjects
    [SerializeField] GameObject player;
    [SerializeField] public GameObject rocket;
    public GameObject three;

    // move player to a specific room where the signs and instructions all will be
    public void Room() {
        
        GameObject game = GameObject.Find("RoomTriggers");
        HazardInstruct script = game.GetComponent<HazardInstruct>();
        GameObject[] rocketrooms = script.rooms; 
        GameObject randomroom = rocketrooms[15];
        //moving all of the rocket and player to the new room
        player.transform.position = new Vector3(randomroom.transform.position.x, randomroom.transform.position.y, 5);
        rocket.transform.position = new Vector3(randomroom.transform.position.x, randomroom.transform.position.y, 3);
        //sets the next instruction sign to active so people can see it
        three.SetActive(true);
    }
}
