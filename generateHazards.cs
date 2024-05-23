using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class generateHazards : MonoBehaviour
{

    //creates the grids of all the rooms to be accessed later
    public int numBats = 2;
    public int numPits = 2;
    public int numRooms = 30;
    // Start is called before the first frame update
    void Start()
    {
        //iterates and keeps count of num bats and num pits
        int[] rooms = new int[numRooms];
        for (int i = 0; i < numBats; i++)
        {
            int temp = Random.Range(0, numRooms);
            while (rooms[temp] > 0)
            {
               temp = Random.Range(0, numRooms);
            }
            rooms[temp] = 1;
        }
        for (int i = 0; i < numPits; i++)
        {
            int temp = Random.Range(0, numRooms);
            while (rooms[temp] > 0)
            {
                temp = Random.Range(0, numRooms);
            }
            rooms[temp] = 2;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
