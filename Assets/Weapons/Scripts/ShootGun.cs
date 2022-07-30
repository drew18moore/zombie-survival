using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootGun : MonoBehaviour
{
    [SerializeField] Transform pistol;
    Vector2 direction;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float bulletVel;

    private void Update()
    {
        
    }

    void OnFire()
    {
        Shoot();
    }

    void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletVel);
    }
}
