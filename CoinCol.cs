using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script to collect coins
public class CoinCol : MonoBehaviour
{
    //start off with 0 coins
    public int coinnum = 0;
    //gameobject to show the amount of coins player has
    public GameObject coinCount;
    //displaying the amount of coins
    //0 at start,
    void Start() {
        coinCount.GetComponent<Text>().text = "Coins: " + coinnum;
    }
    //on trigger with a coin
    //destroy the coin
    //increase coin count
    //change the text to reflect that
    public void OnTriggerEnter2D(Collider2D col) {
        if(col.tag.Equals("coins")) {
            Destroy(col.gameObject);
            coinnum++;
            coinCount.GetComponent<Text>().text = "Coins: " + coinnum;
            //Debug.Log(coinnum);
        }

    }
    //shop function to see if coins have enough value to be used in shop
    public bool canSubtract(int n) {
        return (coinnum - n >= 0);
    }

    //subtract coins after being used
    //called in shop script
    public void subtractCoins(int n) {
        coinnum -= n;
        coinCount.GetComponent<Text>().text = "Coins: " + coinnum;
    }
}
