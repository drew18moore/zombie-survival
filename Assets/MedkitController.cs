using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitController : MonoBehaviour
{
    [SerializeField] float bonusHP = 50f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerHealthController>().Health += bonusHP;
            Destroy(gameObject);
        }
    }
}
