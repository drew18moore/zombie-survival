using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitcher : MonoBehaviour
{
    public List<GameObject> guns;

    int totalWeapons;
    public int starterWeaponIndex;

    public int currentWeaponIndex;
    public GameObject currentWeapon;

    // Input
    [SerializeField] PlayerInput input;
    [SerializeField] InputAction scrollAction;

    void Start()
    {
        /*
        totalWeapons = transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }
        currentWeapon = guns[starterWeaponIndex];
        currentWeapon.SetActive(true);
        */
        scrollAction = input.actions["MouseScrollY"];
        
        guns = new List<GameObject>();
        currentWeapon = null;
    }

    void Update()
    {
        if (guns.Count > 1)
        {
            if (scrollAction.ReadValue<float>() > 0)
            {
                // SCROLL UP (switch to next weapon)
                print("SCROLL UP");
                currentWeapon.SetActive(false);
                if (currentWeaponIndex > 0)
                    currentWeaponIndex--;
                else
                    currentWeaponIndex = totalWeapons - 1;
                //guns[currentWeaponIndex].SetActive(true);
                currentWeapon = guns[currentWeaponIndex];
                currentWeapon.SetActive(true);
            }

            else if (scrollAction.ReadValue<float>() < 0)
            {
                // SCROLL DOWN (switch to previous weapon)
                print("SCROLL DOWN");
                currentWeapon.SetActive(false);
                if (currentWeaponIndex < totalWeapons - 1)
                    currentWeaponIndex++;
                else
                    currentWeaponIndex = 0;
                //guns[currentWeaponIndex].SetActive(true);
                currentWeapon = guns[currentWeaponIndex];
                currentWeapon.SetActive(true);
            }
        }
        
    }

    public void AddWeapon(GameObject weapon)
    {
        if (!guns.Contains(weapon))
        {
            GameObject go = Instantiate(weapon, transform.position + weapon.transform.position, Quaternion.identity);
            guns.Add(go);
            go.transform.parent = transform;
            go.name = weapon.name;

            if (currentWeapon != null)
                currentWeapon.SetActive(false);
            currentWeapon = go;
            currentWeapon.SetActive(true);
            currentWeaponIndex = guns.IndexOf(go);
            totalWeapons++;
        }
    }
}
