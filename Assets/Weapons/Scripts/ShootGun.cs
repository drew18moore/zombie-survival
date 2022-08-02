using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootGun : MonoBehaviour
{
    [SerializeField] GameObject pistolController;
    [SerializeField] GameObject rifleController;
    Vector2 direction;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform pistolShootPoint;
    [SerializeField] Transform rifleShootPoint;
    [SerializeField] float bulletVel;

    bool pistolCanShoot = false;
    bool rifleCanShoot = false;

    private void Update()
    {
        pistolCanShoot = pistolController.activeSelf;
        //print("CAN SHOOT PISTOL?: " + pistolCanShoot);

        rifleCanShoot = rifleController.activeSelf;
        //print("CAN SHOOT RIFLE?: " + rifleCanShoot);
    }

    void OnFire()
    {
        if (pistolCanShoot)
        {
            pistolController.GetComponent<Shoot>().ShootGun();
        }
        else if (rifleCanShoot)
        {
            rifleController.GetComponent<Shoot>().ShootGun();
        }
        
    }

/*
    void ShootPistol()
    {
        GameObject bulletInstance = Instantiate(bullet, pistolShootPoint.position, pistolShootPoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletVel);
    }

    void ShootRifle()
    {
        GameObject bulletInstance = Instantiate(bullet, rifleShootPoint.position, rifleShootPoint.rotation);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletVel);
    }
    */
}
