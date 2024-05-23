using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawning : MonoBehaviour
{
    //same thing as hazard instruct, but wumpus essentially is spawned randomly somewhere else
    public GameObject[] rooms;
    public GameObject wumpus;
    private Vector3 wumpusPosition;
    private int[] rands;
    // Start is called before the first frame update
    void Start()
    {
        //original room from which every thng else is a child
        GameObject originalGameObject = GameObject.Find("RoomTriggers");
        //already put into unity interface
         //gameObject.tag = "Pit";
        // //Debug.Log("hi");
         int c = 0;
        for(int i = 0; i < 29; i++) {
            //populate array of rooms with the room triggers
            rooms[i] = gameObject.transform.GetChild(c).gameObject;
            //update c
            //Debug.Log(rooms[i]);
            c++;
        }
       
    
    //random numbers which will be indexes for an array of rooms to pick which room will have 
    //a given hazard
    int random1 = Random.Range(2,8);
    int random2 = Random.Range(10,15);
    int random3 = Random.Range(16,21);
    int random4 = Random.Range(3,9);
    int random5 = Random.Range(5,25);
    int[] randoms = {random1, random2, random3, random4};
    rands = randoms;
    //Debug.Log(randoms[0]);
    
    //picks a random room for each hazard

    rooms[random1].tag = "Pit";
    rooms[random2].tag = "Bats";
    rooms[random3].tag = "Pit";
    rooms[random4].tag = "Bats";
    rooms[random5].tag = "Wumpus";
    GameObject wumproom = rooms[random5];
    wumpusPosition = wumproom.transform.position;
    
    //spawns wumpus in the room for wumpus and double checks that it is active
    wumpus.transform.position = new Vector3(wumproom.transform.position.x, wumproom.transform.position.y, 5);
    wumpus.SetActive(true);
    
    //need to add something so surrounding rooms get that hint
    
    for(int i =0; i <4; i++) {
        //sets others to warn
        if(randoms[i] < 25 && randoms[i] > 3) {
            int current = randoms[i];
            //rooms[current - 2].tag = "warn";
            rooms[current -1].tag = "warn";
            rooms[current+1].tag = "warn";
            //rooms[current+2].tag = "warn";
        }

        if (randoms[i] <= 3) {
            int current = randoms[i];
            rooms[current + 2].tag = "warn";
            rooms[current + 1].tag = "warn";
        }

        if(randoms[i] >= 25) {
            int current = randoms[i];
            rooms[current -1].tag = "warn";
            rooms[current -2].tag = "warn";
        }
    }

    
    rooms[random5 + 1].tag = "WumpWarn";
    rooms[random5 - 1].tag = "WumpWarn";
    
    for (int i = 0; i < rands.Length; i++) {
        Debug.Log(rooms[rands[i]].tag);
    }
    
    }
    //untag function
    public void Untag(string room) {
        
        for (int i = 0; i <= 28; i++) {
            if (rooms[i].name.Equals(room)) {
                rooms[i-1].tag = "Untagged";
                rooms[i + 1].tag = "Untagged";
                
            }
        }
    }
    //remove trap function for shop
    public void removeTrap() {
        // get random value idx representing a bit for a bit
        int r = Random.Range(0,3);
        // get the index in rooms that it correspnds
        int ridx = rands[r];
        rooms[ridx].tag = "Untagged";
        for (int i = 0; i < rands.Length; i++) {
            Debug.Log(rooms[rands[i]].tag);
        }
    }
    //returns wumpus position for shop thing to teleport to wumpus
    public Vector3 getWumpusPosition() {
        return wumpusPosition;
    }
}
