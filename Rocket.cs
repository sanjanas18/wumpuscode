using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    // gameobjects
    [SerializeField] GameObject player;
    [SerializeField] public GameObject rocket;

    // move player to a random room if clicked on rocket
    public void randomRoom() {
        //pics random room in array of all the rooms
        int rand = Random.Range(1,28);
        GameObject game = GameObject.Find("RoomTriggers");
        HazardSpawning script = game.GetComponent<HazardSpawning>();
        GameObject[] rocketrooms = script.rooms; 
        GameObject randomroom = rocketrooms[rand];
        //makes sure you cannot go into a room with a hazard
        //teleports
        if(randomroom.tag != "Pit" || randomroom.tag != "Wumpus" || randomroom.tag != "Bats" || randomroom.tag != "warn") {
        player.transform.position = new Vector3(randomroom.transform.position.x, randomroom.transform.position.y, 5);
        rocket.transform.position = new Vector3(randomroom.transform.position.x, randomroom.transform.position.y, 3);
        }
        //if the room is picked has a hazard, go to a different room
        else {
            randomRoom();
        } 
    }
}
