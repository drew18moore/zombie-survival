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
    public float damage;

    // Input
    PlayerInput input;
    [SerializeField] InputAction fireAction;

    private void Start()
    {
        input = GameObject.Find("Player").GetComponent<PlayerInput>();
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
        if (gameObject.name == "ShotgunController")
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject pelletInstance1 = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                GameObject pelletInstance2 = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                GameObject pelletInstance3 = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                pelletInstance1.GetComponent<Rigidbody2D>().AddForce(pelletInstance1.transform.right * bulletSpeed + pelletInstance1.transform.up * 25f);
                pelletInstance2.GetComponent<Rigidbody2D>().AddForce(pelletInstance2.transform.right * bulletSpeed);
                pelletInstance3.GetComponent<Rigidbody2D>().AddForce(pelletInstance3.transform.right * bulletSpeed - pelletInstance3.transform.up * 25f);
            }
        }
        else
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject bulletInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletSpeed);
            }
        }
        
        
    }    
}
