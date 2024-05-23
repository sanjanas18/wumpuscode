using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WumpusRotation : MonoBehaviour
{
    //wumpus automatically rotates gun when shooting
    void Start()
    {
        //starts the method for rotating for a certain amount of time
        InvokeRepeating("RotateGun", 0f, 0.0075f);
    }

    void RotateGun()
    {
        //actually rotates the transform of the gun repeatedly
        transform.Rotate(0f,0f,1f, Space.Self);
    }
}
