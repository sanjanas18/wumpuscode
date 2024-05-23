using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TurnOff", 1.1f);
    }

    public void TurnOff() {
        gameObject.SetActive(false);
    }
}
