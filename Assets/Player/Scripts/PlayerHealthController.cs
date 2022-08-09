using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float health;

    [SerializeField] private GameObject healthBarUI;
    [SerializeField] private Slider slider;

    private void Start()
    {
        health = maxHealth;
    }

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            healthBarUI.SetActive(true);
            health = value;
            print("ENEMY HEALTH UPDATED TO: " + health);

            slider.value = CalculateHealth();

            if (health <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private float CalculateHealth()
    {
        return health / maxHealth;
    }
}
