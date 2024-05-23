using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    //platys music
    void Start()
    {
        //sets it to autoplay
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
