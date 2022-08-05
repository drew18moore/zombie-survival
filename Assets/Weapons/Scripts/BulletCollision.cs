using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] WeaponSwitcher weaponSwitcher;

    private void Start()
    {
        weaponSwitcher = GameObject.Find("WeaponController").GetComponent<WeaponSwitcher>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealthController>().Health -= weaponSwitcher.currentWeapon.GetComponent<Shoot>().damage;
        }
    }
}
