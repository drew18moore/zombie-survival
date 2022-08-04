using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject bullet;

    public float bulletSpeed;
    public float fireRate;
    public float nextFire;

    // Input
    [SerializeField] PlayerInput input;
    [SerializeField] InputAction fireAction;

    private void Start()
    {
        fireAction = input.actions["Fire"];
    }

    private void Update()
    {
        if (fireAction.ReadValue<float>() == 1)
        {
            ShootGun();
        }
    }

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
