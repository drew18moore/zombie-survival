using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] float cost = 1000f;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            text.SetActive(true);
            if (GameObject.Find("Player").GetComponent<PointsController>().Points >= cost)
            {
                GameObject.Find("Player").GetComponent<PointsController>().Points -= cost;
                spawner.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.SetActive(false);
    }
}
