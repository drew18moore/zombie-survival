using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject bullet;

    public float bulletSpeed;
    public float fireRate;
    public float nextFire;

    public void ShootGun() {
        //print("SHOOTING: " + transform.name);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulletInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletSpeed);
        }
        
    }    
}
