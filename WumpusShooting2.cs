using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WumpusShooting2 : MonoBehaviour
{

    //guns of wumpus
    public Transform gunPoint1;
    public Transform gunPoint2;
    public Transform gunPoint3;
    public Transform gunPoint4;
    /*
    public Transform gunPoint5;
    public Transform gunPoint6;
    public Transform gunPoint7;
    public Transform gunPoint8;
    */

    //other globals
    public GameObject bulletPrefab; 
    public GameObject colliderReferenceLayer;

    public float ShootDelaySeconds = 0.25f;
    public float ShootStopSeconds = 2f;

    public float bulletForce = 720f;

    public bool shooting = false;

    //invokes the shoots (wump shoot) when shooting starts
    public void ShootBegin()
    {
        //stop shooting for five seconds
        //then shoot
        Invoke("StopShoot", 5);
        shooting = true;
        InvokeRepeating("WumpShoot", 0f, ShootDelaySeconds);
    }

    void WumpShoot() 
    {
        //if shooting
        //shoot bunch of bullets
        //wumpus rotates in wumpus rotation script
        if (shooting){
            //gun 1
            GameObject bullet1 = (GameObject) Instantiate(bulletPrefab, gunPoint1.position, gunPoint1.rotation);
            bullet1.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(gunPoint1.up * bulletForce, ForceMode2D.Impulse);
            
            //gun 2
            GameObject bullet2 = (GameObject) Instantiate(bulletPrefab, gunPoint2.position, gunPoint2.rotation);
            bullet2.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(gunPoint2.up * bulletForce, ForceMode2D.Impulse);
            
            //gun 3
            GameObject bullet3 = (GameObject) Instantiate(bulletPrefab, gunPoint3.position, gunPoint3.rotation);
            bullet3.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(gunPoint3.up * bulletForce, ForceMode2D.Impulse);
            
            //gun 4
            GameObject bullet4 = (GameObject) Instantiate(bulletPrefab, gunPoint4.position, gunPoint4.rotation);
            bullet4.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
            rb4.AddForce(gunPoint4.up * bulletForce, ForceMode2D.Impulse);
            
            /* //gun 5
            GameObject bullet5 = (GameObject) Instantiate(bulletPrefab, gunPoint5.position, gunPoint5.rotation);
            bullet5.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
            rb1.AddForce(gunPoint5.up * bulletForce, ForceMode2D.Impulse);
            
            //gun 6
            GameObject bullet6 = (GameObject) Instantiate(bulletPrefab, gunPoint6.position, gunPoint6.rotation);
            bullet6.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb6 = bullet6.GetComponent<Rigidbody2D>();
            rb2.AddForce(gunPoint6.up * bulletForce, ForceMode2D.Impulse);
            
            //gun 7
            GameObject bullet7 = (GameObject) Instantiate(bulletPrefab, gunPoint7.position, gunPoint7.rotation);
            bullet7.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb7 = bullet7.GetComponent<Rigidbody2D>();
            rb3.AddForce(gunPoint7.up * bulletForce, ForceMode2D.Impulse);
            
            //gun 8
            GameObject bullet8 = (GameObject) Instantiate(bulletPrefab, gunPoint8.position, gunPoint8.rotation);
            bullet8.layer = colliderReferenceLayer.layer;
            Rigidbody2D rb8 = bullet8.GetComponent<Rigidbody2D>();
            rb4.AddForce(gunPoint8.up * bulletForce, ForceMode2D.Impulse); */
            
        }
    }

    void StopShoot()
    {
        shooting = false;
    }
}
