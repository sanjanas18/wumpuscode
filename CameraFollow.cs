using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//older script to habve camera follow player
//not really used, but was at the beggining of the very first version of the game
//also used in case for instructions scene in case the player goes somewhere else
public class CameraFollow : MonoBehaviour
{   public Transform playerToFollow;
    public Vector3 offet;
    [Range(1,10)]
    public float smooth;
    //late update makes it smoother
    void LateUpdate() {
        //target area
        Vector3 targetpos = playerToFollow.position + offet;
        Vector3 smoothpos = Vector3.Lerp(transform.position, targetpos, smooth*Time.deltaTime);
        //setting thje position of the camera to the target (the player)
        transform.position = targetpos;
    }
}
