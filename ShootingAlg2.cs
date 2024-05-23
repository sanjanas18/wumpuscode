using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAlg2 : MonoBehaviour
{
    //another shooting algorithm, but revised
    //this one takes into account different layers so it hits the right stuff (wumpus)
    public Transform gunPoint;
    public GameObject bulletPrefab; 
    public GameObject colliderReferenceLayer;

    public float bulletForce = 720f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        //instantiate bullet, rotation to where mouse point showing
        //makes sure to shoot on the right layer
        //add force to bullet 
        //bullet forxe = what assigned above
        GameObject bullet = (GameObject) Instantiate(bulletPrefab, gunPoint.position, gunPoint.rotation);
        bullet.layer = colliderReferenceLayer.layer;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(gunPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
