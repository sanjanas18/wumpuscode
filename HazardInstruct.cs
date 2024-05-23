using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//an easy, dummed down version of the actual hazard generation
//used for the instruction scene
public class HazardInstruct : MonoBehaviour
{
    //all variables
    //the rooms as previously designated in inspector and in generate hazards script
    public GameObject[] rooms;
    
    private Vector3 wumpusPosition;
    private int[] rands;
    // Start is called before the first frame update
    void Start()
    {
        //saying the original, main room
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
       
    
    //random integers to randomly pick where each hazard will be in the array of rooms
    int random1 = Random.Range(1,2);
    //int random1 = 6;
    int random2 = Random.Range(10,15);
    int random3 = Random.Range(16,21);
    int random4 = Random.Range(3,9);
    int random5 = Random.Range(5,25);
    int[] randoms = {random1, random2, random3, random4};
    rands = randoms;
    //Debug.Log(randoms[0]);
    
    //picks a random room for each hazard
    //will be assigned the tag of that
    //in player, if collides with a trigger with said tag, something specific happens

    rooms[random1].tag = "Pit";
    rooms[random2].tag = "Bats";
    rooms[random3].tag = "Pit";
    rooms[random4].tag = "Bats";
    rooms[random5].tag = "Wumpus";
    GameObject wumproom = rooms[random5];
    //goes to position of wumpus
    //for shop
    wumpusPosition = wumproom.transform.position;
    
 
   
    
    for(int i =0; i <4; i++) {
        //sets others to warn
        if(randoms[i] < 25 && randoms[i] > 3) {
            int current = randoms[i];
            //rooms[current - 2].tag = "warn";
            rooms[current -1].tag = "warn";
            rooms[current+1].tag = "warn";
            //rooms[current+2].tag = "warn";
        }
        //other cases
        if (randoms[i] <= 3) {
            int current = randoms[i];
            rooms[current + 2].tag = "warn";
            rooms[current + 1].tag = "warn";
        }
        //other cases
        if(randoms[i] >= 25) {
            int current = randoms[i];
            rooms[current -1].tag = "warn";
            rooms[current -2].tag = "warn";
        }
    }

    //two random surroumdimg rooms get the wumpus warning (to be difficult)
    rooms[random5 + 1].tag = "WumpWarn";
    rooms[random5 - 1].tag = "WumpWarn";
    
    for (int i = 0; i < rands.Length; i++) {
        Debug.Log(rooms[rands[i]].tag);
    }
    
    }
    //function tp unassign a room with the wu,pus, or pit tag
    //so a same palce canmot be a pit twice
    public void Untag(string room) {
        
        for (int i = 0; i <= 28; i++) {
            if (rooms[i].name.Equals(room)) {
                rooms[i-1].tag = "Untagged";
                rooms[i + 1].tag = "Untagged";
                
            }
        }
    }
    //remove trap on the shop section
    public void removeTrap() {
        // get random value idx representing a bit for a bit
        int r = Random.Range(0,3);
        // get the index in rooms that it correspnds
        int ridx = rands[r];
        //untags it
        rooms[ridx].tag = "Untagged";
        for (int i = 0; i < rands.Length; i++) {
            Debug.Log(rooms[rands[i]].tag);
        }
    }

    
}
