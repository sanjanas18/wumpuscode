using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script shoots the gun

public class Shooting : MonoBehaviour
{

//public objects
    public Transform gunPoint;
    public GameObject bulletPrefab; 

    ///bullet force you can change
    public float bulletForce = 24f;

    // Update is called once per frame
    void Update()
    {
        //if clicked, do shoot method
        //any time during game
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
         
    }

    void Shoot() 
    {
        //instantiate bullet, rotation to where mouse point showing
        //add force to bullet 
        //bullet forxe = what assigned aove
        GameObject bullet = Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunPoint.up * bulletForce, ForceMode2D.Impulse);

    
    }

    // void OnCollisionEnter2D(Collision2D col2d) {
    //      if (col2d.collider.name == "Player") {
    //          Physics2D.IgnoreCollision(col2d.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //      }
    //  }
}
