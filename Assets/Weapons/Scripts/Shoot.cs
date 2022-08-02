using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject bullet;

    public float bulletSpeed;

    public void ShootGun() {
        print("SHOOTING: " + transform.name);
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletSpeed);
    }    
}
